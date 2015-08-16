using System.Collections.Generic;

namespace GameCreator.Contracts.Resources
{
    /// <summary>
    /// Interface for a repository of game resources.
    /// </summary>
    public interface IGameRepository
    {
        /// <summary>
        /// Gets or sets the resource manager for objects.
        /// </summary>
        IIndexedResourceManager<IGameObject> Objects { get; set; }

        /// <summary>
        /// Gets or sets the resource manager for rooms.
        /// </summary>
        IIndexedResourceManager<IGameRoom> Rooms { get; set; }
    }
}
