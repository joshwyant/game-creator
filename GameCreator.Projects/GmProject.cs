using App.Resources;
using App.Contracts;
using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCreator.Projects
{
    public class GmProject : IProject
    {
        public IAppRepository Repository { get; set; }

        public IGameMakerSettings Settings { get; set; }

        public GmProject()
        {
            Settings = new GmSettings();
            Repository = AppRepository.Container.GetInstance<IAppRepository>();
        }
    }
}
