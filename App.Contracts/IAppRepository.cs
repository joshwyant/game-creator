namespace App.Contracts
{
    /// <summary>
    /// Interface for a repository of app resources.
    /// </summary>
    public interface IAppRepository
    {
        /// <summary>
        ///  Gets or sets the resource manager for sprites.
        /// </summary>
        IIndexedResourceManager<IAppSprite> Sprites { get; set; }

        /// <summary>
        ///  Gets or sets the resource manager for sprites.
        /// </summary>
        IIndexedResourceManager<IAppSound> Sounds { get; set; }

        /// <summary>
        ///  Gets or sets the resource manager for sprites.
        /// </summary>
        IIndexedResourceManager<IAppBackground> Backgrounds { get; set; }

        /// <summary>
        ///  Gets or sets the resource manager for sprites.
        /// </summary>
        IIndexedResourceManager<IAppPath> Paths { get; set; }

        /// <summary>
        ///  Gets or sets the resource manager for sprites.
        /// </summary>
        IIndexedResourceManager<IAppScript> Scripts { get; set; }

        /// <summary>
        ///  Gets or sets the resource manager for sprites.
        /// </summary>
        IIndexedResourceManager<IAppDataFile> DataFiles { get; set; }

        /// <summary>
        ///  Gets or sets the resource manager for sprites.
        /// </summary>
        IIndexedResourceManager<IAppFont> Fonts { get; set; }

        /// <summary>
        ///  Gets or sets the resource manager for sprites.
        /// </summary>
        IIndexedResourceManager<IAppTimeline> Timelines { get; set; }

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
