using App.Contracts;
using LightInject;

namespace App.Resources
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            // Register the app repository
            serviceRegistry.Register<IAppRepository, AppRepository>();

            // Register the app resource types
            serviceRegistry.Register<IAppSprite, AppSprite>();
            serviceRegistry.Register<IAppSound, AppSound>();
            serviceRegistry.Register<IAppBackground, AppBackground>();
            serviceRegistry.Register<IAppPath, AppPath>();
            serviceRegistry.Register<IAppScript, AppScript>();
            serviceRegistry.Register<IAppDataFile, AppDataFile>();
            serviceRegistry.Register<IAppFont, AppFont>();
            serviceRegistry.Register<IAppTimeline, AppTimeLine>();
            serviceRegistry.Register<IAppObject, AppObject>();
            serviceRegistry.Register<IAppRoom, AppRoom>();
        }
    }
}
