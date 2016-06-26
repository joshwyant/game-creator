using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Contracts;
using System.IO;

namespace GameCreator.Projects
{
    public class GmFileProjectType : IProjectType, IGmFileProjectType
    {
        public string Description
        {
            get
            {
                return "Game Maker Files (4.0-8.1)";
            }
        }

        public string Extension
        {
            get
            {
                return "*";
            }
        }

        public bool IsSingleFile
        {
            get
            {
                return true;
            }
        }

        public GmVersion SpecificVersion { get; set; }

        public IEnumerable<GmVersion> Versions
        {
            get
            {
                return new[]
                {
                    GmVersion.Version4_0,
                    GmVersion.Version4_1,
                    GmVersion.Version4_2,
                    GmVersion.Version4_3,
                    GmVersion.Version5_0,
                    GmVersion.Version5_1,
                    GmVersion.Version5_2,
                    GmVersion.Version5_3,
                    GmVersion.Version6_0,
                    GmVersion.Version6_1,
                    GmVersion.Version7_0,
                    GmVersion.Version8_0,
                    GmVersion.Version8_1
                };
            }
        }

        public GmFileProjectType() { }

        public GmFileProjectType(GmVersion version) { SpecificVersion = version; }

        public void LoadProject(IProject project, string location)
        {
            Stream file = null, gmk = null;

            try
            {
                file = File.OpenRead(location);

                if (SpecificVersion == GmVersion.Version7_0)
                    gmk = new GMKIn(file);

                var s = gmk ?? file;

                using (var sr = new BinaryReader(s))
                {
                    var reader = new GmFileProjectReader(project, sr);

                    reader.Read();
                }
            }
            finally
            {
                if (gmk != null)
                {
                    gmk.Dispose();
                }

                if (file != null)
                {
                    file.Dispose();
                }
            }
        }

        public void SaveProject(IProject project, string location)
        {
            Stream file = null, gmk = null;

            try
            {
                file = File.Open(location, FileMode.Create);

                if (SpecificVersion == GmVersion.Version7_0)
                    gmk = new GMKOut(file);

                var s = gmk ?? file;

                using (var sw = new BinaryWriter(s))
                {
                    var writer = new GmFileProjectWriter(project, sw);

                    writer.Write();
                }
            }
            finally
            {
                if (gmk != null)
                {
                    gmk.Dispose();
                }

                if (file != null)
                {
                    file.Dispose();
                }
            }
        }
    }
}
