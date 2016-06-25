using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Projects
{
    public class GmFileProjectService : IProjectService
    {
        public void LoadProject(IProject project, IProjectType type, string location)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            var gmFileType = type as IGmFileProjectType;

            if (gmFileType == null)
                throw new ApplicationException($"The type of project \"{type.Description}\" cannot be loaded as a Game Maker File.");

            gmFileType.LoadProject(project, location);
        }

        public void SaveProject(IProject project, IProjectType type, string location)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            var gmFileType = type as IGmFileProjectType;

            if (gmFileType == null)
                throw new ApplicationException($"The type of project \"{type.Description}\" cannot be saved as a Game Maker File.");

            gmFileType.SaveProject(project, location);
        }
    }
}
