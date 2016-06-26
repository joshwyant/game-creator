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

        public int LastInstanceIdPlaced { get; set; }
        public int LastTileIdPlaced { get; set; }
        public GameInformation GameInformation { get; set; }
        public List<string> LibraryCreationCodes { get; set; }
        public List<int> ExecutableRoomList { get; set; }
        public List<TreeResource> ResourceTree { get; set; }

        public GmProject()
        {
            Settings = new GmSettings();
            Repository = AppRepository.Container.GetInstance<IAppRepository>();
            LastInstanceIdPlaced = 100000;
            LastTileIdPlaced = 10000000;
            GameInformation = new GameInformation();
        }
    }
}
