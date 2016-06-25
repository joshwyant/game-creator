using GameCreator.Contracts;
using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Projects
{
    interface IGmFileProjectType
    {
        GmVersion SpecificVersion { get; set; }

        void LoadProject(IProject project, string location);

        void SaveProject(IProject project, string location);
    }
}
