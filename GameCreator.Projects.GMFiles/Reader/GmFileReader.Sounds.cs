using GameCreator.Api.Resources;

namespace GameCreator.Projects.GMFiles
{
    internal partial class GmFileReader
    {
        private void ReadSounds()
        {
            var version = ReadInt();

            var count = ReadInt();

            for (var i = 0; i < count; i++)
            {
                Project.Sounds.NextIndex = i;

                if (ReadInt() != 0)
                {
                    var sound = Project.Sounds.Create();

                    sound.Name = ReadString();

                    version = ReadInt();

                    if (version == 440)
                        sound.Type = (SoundFileType)ReadInt();

                    if (version >= 600)
                        sound.Kind = (SoundKind)Reader.ReadUInt32();

                    sound.Extension = ReadString();

                    if (version >= 600)
                    {
                        sound.Filename = ReadString();

                        if (Reader.ReadUInt32() != 0)
                        {
                            if (version == 600)
                            {
                                sound.MusicData = ReadZipped();
                            }
                        }
                    }

                    if (version == 440)
                    {
                        if (sound.Type != SoundFileType.None)
                        {
                            sound.MusicData = ReadZipped();
                        }

                        sound.AllowSoundEffects = ReadBool();
                        sound.Buffers = ReadInt();
                        sound.LoadOnlyOnUse = ReadInt();
                    }

                    if (version >= 600)
                    {
                        sound.Effects = (SoundEffects)ReadInt();
                        sound.Volume = Reader.ReadDouble();
                        sound.Pan = Reader.ReadDouble();
                        sound.Preload = ReadBool();
                    }
                }
            }
        }
    }
}
