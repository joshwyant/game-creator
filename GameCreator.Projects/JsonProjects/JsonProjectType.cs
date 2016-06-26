using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCreator.Contracts;
using GameCreator.Projects.JsonProjects.Models;
using Newtonsoft.Json;

namespace GameCreator.Projects.JsonProjects
{
    public partial class JsonProjectType : IProjectType
    {
        public string Description { get { return "JSON Projects"; } }

        public string Extension { get { return "json"; } }

        public bool IsSingleFile { get { return false; } }

        public GmVersion SpecificVersion { get; set; }

        public IEnumerable<GmVersion> Versions
        {
            get
            {
                return new[]
                {
                    GmVersion.Version4_3,
                    GmVersion.Version5_0,
                    GmVersion.Version5_1,
                    GmVersion.Version5_2,
                    GmVersion.Version5_3,
                    GmVersion.Version6_0
                };
            }
        }
    }
}
