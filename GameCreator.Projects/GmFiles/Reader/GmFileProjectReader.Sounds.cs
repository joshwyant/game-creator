using App.Contracts;
using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace GameCreator.Projects
{
    partial class GmFileProjectReader
    {
        void readSounds()
        {
            int version = getInt();

            int count = getInt();

            for (var i = 0; i < count; i++)
            {
                project.Repository.Sounds.NextIndex = i;

                if (getInt() != 0)
                {
                    var sound = project.Repository.Sounds.Add();

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
