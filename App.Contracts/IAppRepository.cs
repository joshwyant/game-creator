namespace App.Contracts
{
    /// <summary>
    /// Interface for a repository of app resources.
    /// </summary>
    public interface IAppRepository
    {
        /// <summary>
        /// Gets or sets the resource manager for objects.
        /// </summary>
        IIndexedResourceManager<IAppObject> Objects { get; set; }

        /// <summary>
        /// Gets or sets the resource manager for rooms.
        /// </summary>
        IIndexedResourceManager<IAppRoom> Rooms { get; set; }
    }
}
