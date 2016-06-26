using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCreator.Contracts;
using GameCreator.Projects.JsonProjects.Models;
using Newtonsoft.Json;
using System.IO;

namespace GameCreator.Projects.JsonProjects
{
    public partial class JsonProjectType
    {
        JsonSerializerSettings settings;
        IProject project;

        public void SaveProject(IProject project, string location)
        {
            this.project = project;

            CreateDirectoryStructure(project.ResourceTree, location);

            settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };

            var rootFile = new JsonRootProject();
            rootFile.Version = SpecificVersion;

            ExportSprites(location);
            ExportScripts(location);

            // Export icon
            var icoFileName = Path.Combine(location, "app.ico");
            File.WriteAllBytes(icoFileName, project.Settings.IconData);

            // Write project file
            var rootFileName = Path.Combine(location, "project.json");
            File.WriteAllText(rootFileName, JsonConvert.SerializeObject(rootFile, settings));
        }

        void CreateDirectoryStructure(IEnumerable<TreeResource> resources, string location)
        {
            if (!Directory.Exists(location))
                Directory.CreateDirectory(location);

            foreach (var resource in resources)
            {
                if (resource.Status == TreeResourceStatus.Primary || resource.Status == TreeResourceStatus.Group)
                {
                    string name = Path.Combine(location, resource.Name);

                    CreateDirectoryStructure(resource.Contents, name);
                }
            }
        }

        void EnumerateFiles(string location, TreeResourceKind kind, Action<string, string, int> action)
        {
            var resourceRoot = project.ResourceTree.Single(rt => rt.Grouping == kind);
            var resourceRootDirectory = Path.Combine(location, resourceRoot.Name);

            recurse(resourceRootDirectory, resourceRoot.Contents, action);
        }

        void recurse(string location, IEnumerable<TreeResource> resources, Action<string, string, int> action)
        {
            foreach (var resource in resources)
            {
                if (resource.Status == TreeResourceStatus.Secondary)
                    action(location, resource.Name, resource.Index);

                if (resource.Status == TreeResourceStatus.Group)
                {
                    var subDirectory = Path.Combine(location, resource.Name);
                    recurse(subDirectory, resource.Contents, action);
                }
            }
        }

        void ExportScripts(string location)
        {
            EnumerateFiles(location, TreeResourceKind.Scripts, (subdirectory, name, idx) => {
                var fileName = $"{name}.gmscript";
                var fullPath = Path.Combine(subdirectory, fileName);

                File.WriteAllText(fullPath, project.Repository.Scripts[idx].Code);
            });
        }

        void ExportSprites(string location)
        {
            EnumerateFiles(location, TreeResourceKind.Sprites, (subdirectory, name, idx) => {
                var imagePath = Path.Combine(subdirectory, name);

                if (!Directory.Exists(imagePath))
                    Directory.CreateDirectory(imagePath);

                foreach (var subImage in project.Repository.Sprites[idx].SubImages)
                {
                    var fileName = $"{subImage.Key}.bmp";
                    var fullPath = Path.Combine(imagePath, fileName);
                    File.WriteAllBytes(fullPath, subImage.Value);
                }
            });
        }
    }
}
