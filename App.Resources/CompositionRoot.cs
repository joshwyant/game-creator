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
            serviceRegistry.Register<IAppTimeline, AppTimeline>();
            serviceRegistry.Register<IAppObject, AppObject>();
            serviceRegistry.Register<IAppRoom, AppRoom>();

            // Register teh resource managers
            serviceRegistry.Register<IIndexedResourceManager<IAppSprite>, IndexedResourceManager<IAppSprite>>();
            serviceRegistry.Register<IIndexedResourceManager<IAppSound>, IndexedResourceManager<IAppSound>>();
            serviceRegistry.Register<IIndexedResourceManager<IAppBackground>, IndexedResourceManager<IAppBackground>>();
            serviceRegistry.Register<IIndexedResourceManager<IAppPath>, IndexedResourceManager<IAppPath>>();
            serviceRegistry.Register<IIndexedResourceManager<IAppScript>, IndexedResourceManager<IAppScript>>();
            serviceRegistry.Register<IIndexedResourceManager<IAppDataFile>, IndexedResourceManager<IAppDataFile>>();
            serviceRegistry.Register<IIndexedResourceManager<IAppFont>, IndexedResourceManager<IAppFont>>();
            serviceRegistry.Register<IIndexedResourceManager<IAppTimeline>, IndexedResourceManager<IAppTimeline>>();
            serviceRegistry.Register<IIndexedResourceManager<IAppObject>, IndexedResourceManager<IAppObject>>();
            serviceRegistry.Register<IIndexedResourceManager<IAppRoom>, IndexedResourceManager<IAppRoom>>();
        }
    }
}
