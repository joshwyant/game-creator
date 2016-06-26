using GameCreator.Contracts.Services;
using GameCreator.Projects.JsonProjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Projects
{
    public class JsonProjectService : IProjectService
    {
        public void LoadProject(IProject project, IProjectType type, string location)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            var gmJsonType = type as JsonProjectType;

            if (gmJsonType == null)
                throw new ApplicationException($"The type of project \"{type.Description}\" cannot be loaded as a Game Creator JSON project.");

            gmJsonType.LoadProject(project, location);
        }

        public void SaveProject(IProject project, IProjectType type, string location)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            var gmJsonType = type as JsonProjectType;

            if (gmJsonType == null)
                throw new ApplicationException($"The type of project \"{type.Description}\" cannot be saved as a Game Creator JSON project.");

            gmJsonType.SaveProject(project, location);
        }
    }
}
