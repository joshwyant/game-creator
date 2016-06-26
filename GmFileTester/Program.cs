using GameCreator.Projects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmFileTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"\\psf\Home\Google Drive\To Organize\gm\2.gm6";

            var project = new GmProject();

            var reader = new GmFileProjectService();

            var projectType = new GmFileProjectType();

            reader.LoadProject(project, projectType, file);

            Debugger.Break();
        }
    }
}
