using GameCreator.Resources.Api;

namespace GameCreator.Projects.GMFiles
{
    partial class GmFileReader
    {
        void readSounds()
        {
            var version = getInt();

            var count = getInt();

            for (var i = 0; i < count; i++)
            {
                project.Sounds.NextIndex = i;

                if (getInt() != 0)
                {
                    var sound = project.Sounds.Create();

                    sound.Name = getString();

                    version = getInt();

                    if (version == 440)
                        sound.Type = (SoundFileType)getInt();

                    if (version >= 600)
                        sound.Kind = (SoundKind)reader.ReadUInt32();

                    sound.Extension = getString();

                    if (version >= 600)
                    {
                        sound.Filename = getString();

                        if (reader.ReadUInt32() != 0)
                        {
                            if (version == 600)
                            {
                                sound.MusicData = getZipped();
                            }
                        }
                    }

                    if (version == 440)
                    {
                        if (sound.Type != SoundFileType.None)
                        {
                            sound.MusicData = getZipped();
                        }

                        sound.AllowSoundEffects = getBool();
                        sound.Buffers = getInt();
                        sound.LoadOnlyOnUse = getInt();
                    }

                    if (version >= 600)
                    {
                        sound.Effects = (SoundEffects)getInt();
                        sound.Volume = reader.ReadDouble();
                        sound.Pan = reader.ReadDouble();
                        sound.Preload = getBool();
                    }
                }
            }
        }
    }
}
