using App.Contracts;

namespace App.Resources
{
    /// <summary>
    /// The default app repository.
    /// </summary>
    public class AppRepository : IAppRepository
    {
        public IIndexedResourceManager<IAppObject> Objects { get; set; }

        public IIndexedResourceManager<IAppRoom> Rooms { get; set; }
    }
}
