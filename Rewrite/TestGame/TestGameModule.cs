using GameCreator.Engine;
using Ninject.Modules;

namespace TestGame
{
    public class TestGameModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IResourceContext>().To<TestGameResourceContext>().InSingletonScope();
            Bind<IGameContext>().To<TestGame>().InSingletonScope();
        }
    }
}