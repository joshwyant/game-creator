using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCreator.Projects.Git
{
    public class GitHelper
    {
        string location;
        public GitHelper(string location)
        {
            this.location = location;
        }

        public bool InitializeDirecory()
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "git",
                Arguments = "init .",
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                WorkingDirectory = location,
                CreateNoWindow = true,
            };

            var result = System.Diagnostics.Process.Start(startInfo);

            result.WaitForExit();

            return result.ExitCode == 0;
        }

        public bool AddAllFiles()
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "git",
                Arguments = "add -A",
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                WorkingDirectory = location,
                CreateNoWindow = true,
            };

            var result = System.Diagnostics.Process.Start(startInfo);

            result.WaitForExit();

            return result.ExitCode == 0;
        }

        public bool Commit(string message)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "git",
                Arguments = $"commit -m \"{message}\"",
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                WorkingDirectory = location,
                CreateNoWindow = true,
            };

            var result = System.Diagnostics.Process.Start(startInfo);

            result.WaitForExit();

            return result.ExitCode == 0;
        }

        public bool AddToSourceControl()
        {
            if (!InitializeDirecory())
                return false;

            if (!AddAllFiles())
                return false;

            return Commit("Adding project to source control.");
        }
    }
}
