using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Contracts;

namespace GameCreator.Projects
{
    public class GmkProjectType : IProjectType, IGmFileProjectType
    {
        public string Description
        {
            get
            {
                return "Game Maker 7 Files";
            }
        }

        public string Extension
        {
            get
            {
                return "gmk";
            }
        }

        public bool IsSingleFile
        {
            get
            {
                return true;
            }
        }

        public IEnumerable<GmVersion> Versions
        {
            get
            {
                return new[]
                {
                    GmVersion.Version7_0,
                };
            }
        }

        public GmVersion SpecificVersion { get; set; }

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
