using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using GameCreator.Api.Engine;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using static OpenTK.Audio.OpenAL.AL;

namespace GameCreator.Plugins.OpenTK
{
    // How to use OpenAL with OpenTK:
    // https://github.com/mono/opentk/blob/master/Source/Examples/OpenAL/1.1/Playback.cs
    // Another way: https://stackoverflow.com/a/34667370/936030
    // Wave format: 
    // https://web.archive.org/web/20141213140451/https://ccrma.stanford.edu/courses/422/projects/WaveFormat/
    internal sealed class OpenTKAudioPlugin : IAudioPlugin, IDisposable
    {
        private const bool disabled = false;
        
        //private AudioContext Context { get; }
        
        List<int> buffers = new List<int>();
        List<Source> sources = new List<Source>();
        
        public OpenTKAudioPlugin()
        {
            if (!disabled)
            {
                //Context = new AudioContext();
            }
        }

        public unsafe ISoundEffect LoadSound(Stream stream)
        {
            if (disabled)
            {
                return new SoundInfo(-1, TimeSpan.Zero);
            }
            
            var data = LoadWave(stream, out var channels, out var bits, out var rate);
            var length = CalculateLength(channels, bits, rate, data.Length);

            var bufferId = GenBuffer();
            buffers.Add(bufferId);
            var soundInfo = new SoundInfo(bufferId, length);
            
            fixed (byte* dataPtr = data)
            {
                BufferData(bufferId, GetSoundFormat(channels, bits), (IntPtr)dataPtr, data.Length, rate);
            }

            return soundInfo;
        }

        public void PlaySound(ISoundEffect sound)
        {
            if (disabled)
            {
                return;
            }
            
            var soundInfo = (SoundInfo) sound;
            var sourceId = GenSource();
            var source = new Source(sourceId);
            sources.Add(source);
            soundInfo.Sources.TryAdd(sourceId, source);
            Source(sourceId, ALSourcei.Buffer, soundInfo.BufferId);
            SourcePlay(sourceId);

            Task.Delay(soundInfo.Length).ContinueWith(_ =>
            {
                while (source.IsPlaying()) Thread.Sleep(15);
                soundInfo.Sources.TryRemove(sourceId, out var unused);
                source.Dispose();
            });
        }

        private TimeSpan CalculateLength(int num_channels, int bits_per_sample, int sample_rate, int dataLength)
        {
            return TimeSpan.FromSeconds((double)dataLength / (bits_per_sample >> 3) / num_channels / sample_rate);
        }
        
        // Loads a wave/riff audio file.
        private static byte[] LoadWave(Stream stream, out int num_channels, out int bits_per_sample, out int sample_rate)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            using (var reader = new BinaryReader(stream))
            {
                // RIFF header
                var signature = new string(reader.ReadChars(4));
                if (signature != "RIFF")
                    throw new NotSupportedException("Specified stream is not a wave file.");

                var riff_chunck_size = reader.ReadInt32();

                var format = new string(reader.ReadChars(4));
                if (format != "WAVE")
                    throw new NotSupportedException("Specified stream is not a wave file.");

                // WAVE header
                var format_signature = new string(reader.ReadChars(4));
                if (format_signature != "fmt ")
                    throw new NotSupportedException("Specified wave file is not supported.");

                var format_chunk_size = reader.ReadInt32();
                int audio_format = reader.ReadInt16();
                num_channels = reader.ReadInt16();
                sample_rate = reader.ReadInt32();
                var byte_rate = reader.ReadInt32();
                int block_align = reader.ReadInt16();
                bits_per_sample = reader.ReadInt16();

                var data_signature = new string(reader.ReadChars(4));
                if (data_signature != "data")
                    throw new NotSupportedException("Specified wave file is not supported.");

                var data_chunk_size = reader.ReadInt32();

                return reader.ReadBytes((int)reader.BaseStream.Length);
            }
        }

        private static ALFormat GetSoundFormat(int channels, int bits)
        {
            switch (channels)
            {
                case 1: return bits == 8 ? ALFormat.Mono8 : ALFormat.Mono16;
                case 2: return bits == 8 ? ALFormat.Stereo8 : ALFormat.Stereo16;
                default: throw new NotSupportedException("The specified sound format is not supported.");
            }
        }

        #region Dispose pattern
        private void ReleaseUnmanagedResources()
        {
            sources.ForEach(s => s.Dispose());
            sources.Clear();
            DeleteBuffers(buffers.ToArray());
            buffers.Clear();
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                //Context?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~OpenTKAudioPlugin()
        {
            Dispose(false);
        }
        #endregion
    }
}