using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using GameCreator.Engine.Api;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;

namespace GameCreator.Plugins.OpenTK
{
    // How to use OpenAL with OpenTK:
    // https://github.com/mono/opentk/blob/master/Source/Examples/OpenAL/1.1/Playback.cs
    // Another way: https://stackoverflow.com/a/34667370/936030
    // Wave format: 
    // https://web.archive.org/web/20141213140451/https://ccrma.stanford.edu/courses/422/projects/WaveFormat/
    internal sealed class OpenTKAudioPlugin : IAudioPlugin, IDisposable
    {
        private AudioContext Context { get; }
        
        List<int> buffers = new List<int>();
        List<Source> sources = new List<Source>();
        
        public OpenTKAudioPlugin()
        {
            Context = new AudioContext();
        }

        public ISoundEffect LoadSound(Stream stream)
        {
            var data = LoadWave(stream, out var channels, out var bits, out var rate);
            var length = CalculateLength(channels, bits, rate, data.Length);

            var bufferId = AL.GenBuffer();
            buffers.Add(bufferId);
            var soundInfo = new SoundInfo(bufferId, length);
            
            AL.BufferData(bufferId, GetSoundFormat(channels, bits), data, data.Length, rate);

            return soundInfo;
        }

        public void PlaySound(ISoundEffect sound)
        {
            var soundInfo = (SoundInfo) sound;
            var sourceId = AL.GenSource();
            var source = new Source(sourceId);
            sources.Add(source);
            soundInfo.Sources.TryAdd(sourceId, source);
            AL.Source(sourceId, ALSourcei.Buffer, soundInfo.BufferId);
            AL.SourcePlay(sourceId);

            Task.Delay(soundInfo.Length).ContinueWith(_ =>
            {
                while (source.IsPlaying()) Thread.Sleep(15);
                soundInfo.Sources.TryRemove(sourceId, out var unused);
                source.Dispose();
            });
        }

        private TimeSpan CalculateLength(int channels, int bits, int rate, int dataLength)
        {
            return TimeSpan.FromSeconds((double)dataLength / (rate * channels * (bits >> 4)));
        }
        
        // Loads a wave/riff audio file.
        private static byte[] LoadWave(Stream stream, out int channels, out int bits, out int rate)
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
                int num_channels = reader.ReadInt16();
                var sample_rate = reader.ReadInt32();
                var byte_rate = reader.ReadInt32();
                int block_align = reader.ReadInt16();
                int bits_per_sample = reader.ReadInt16();

                var data_signature = new string(reader.ReadChars(4));
                if (data_signature != "data")
                    throw new NotSupportedException("Specified wave file is not supported.");

                var data_chunk_size = reader.ReadInt32();

                channels = num_channels;
                bits = bits_per_sample;
                rate = sample_rate;

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
            AL.DeleteBuffers(buffers.ToArray());
            buffers.Clear();
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                Context?.Dispose();
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