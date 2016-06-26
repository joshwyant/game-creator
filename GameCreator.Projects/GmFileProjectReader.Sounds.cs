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
            int version = reader.ReadInt32();
            
            for (int count = reader.ReadInt32(), i = 0; i < count; i++)
            {
                project.Repository.Sounds.NextIndex = i;

                if (reader.ReadInt32() != 0)
                {
                    var sound = project.Repository.Sounds.Add();

                    sound.Name = readString();

                    version = reader.ReadInt32();


                }
            }
        }
    }
}
