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
        void readScripts()
        {
            int version = getInt();

            for (int count = getInt(), i = 0; i < count; i++)
            {
                project.Repository.Scripts.NextIndex = i;

                if (getInt() != 0)
                {
                    var script = project.Repository.Scripts.Add();

                    script.Name = getString();

                    version = getInt();

                    script.Code = getString();
                }
            }
        }
    }
}
