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
            serviceRegistry.Register<IAppObject, AppObject>();
            serviceRegistry.Register<IAppRoom, AppRoom>();
        }
    }
}
