using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Contracts;

namespace GameCreator.Projects
{
    public class GmdProjectType : IProjectType, IGmFileProjectType
    {
        public string Description
        {
            get
            {
                return "Game Maker Files (4 and 5)";
            }
        }

        public string Extension
        {
            get
            {
                return "gmd";
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
                };
            }
        }

        public void LoadProject(IProject project, string location)
        {
            (new GmFileProjectType(SpecificVersion)).LoadProject(project, location);
        }

        public void SaveProject(IProject project, string location)
        {
            (new GmFileProjectType(SpecificVersion)).SaveProject(project, location);
        }
    }
}
