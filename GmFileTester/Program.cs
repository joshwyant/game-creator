using GameCreator.Projects;
using GameCreator.Projects.Git;
using GameCreator.Projects.JsonProjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmFileTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"\\psf\Home\Google Drive\To Organize\gm\106.gm6";
            
            var newLocation = $@"\\psf\Home\Projects\GameCreator\{Path.GetFileNameWithoutExtension(file)}";

            if (Directory.Exists(newLocation))
                Directory.Delete(newLocation, true);

            var project = new GmProject();

            var reader = new GmFileProjectService();
            var projectType = new GmFileProjectType();
            reader.LoadProject(project, projectType, file);

            var writer = new JsonProjectService();
            var outputProjectType = new JsonProjectType();
            writer.SaveProject(project, outputProjectType, newLocation);

            var helper = new GitHelper(newLocation);
            helper.AddToSourceControl();

            //Debugger.Break();
        }
    }
}
