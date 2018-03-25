using GameCreator.Engine.Api;
using Ninject.Modules;

namespace GameCreator.Plugins.MonoGame
{
    public class MonoGameModule : NinjectModule
    {
        public override void Load()
        {
            Bind<GameCreatorXnaGame>().ToSelf().InSingletonScope();
            Bind<IGraphicsPlugin>().To<MonoGameGraphicsPlugin>().InSingletonScope();
            Bind<IAudioPlugin>().To<MonoGameAudioPlugin>().InSingletonScope();
            Bind<IInputPlugin>().To<MonoGameInputPlugin>().InSingletonScope();
            Bind<ITimerPlugin>().To<MonoGameTimerPlugin>().InSingletonScope();
        }
    }
}