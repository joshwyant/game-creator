using GameCreator.Api.Engine;
using Ninject.Modules;

namespace GameCreator.Plugins.OpenTK
{
    public class OpenTKModule : NinjectModule
    {
        private OpenTKPluginProvider _provider;
        
        public override void Load()
        {
            if (_provider == null)
            {
                _provider = new OpenTKPluginProvider();
            }
           
            // Workarounds for Ninject trying to load platform-dependent types referenced by OpenTK:

            Bind<IGraphicsPlugin>().ToProvider(_provider.Graphics);
            Bind<IAudioPlugin>().ToProvider(_provider.Audio);
            Bind<IInputPlugin>().ToProvider(_provider.Input);
            Bind<ITimerPlugin>().ToProvider(_provider.Timer);
        }

        public override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _provider?.Dispose();
            }
        }
    }
}