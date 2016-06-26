using System.Collections.Generic;

namespace App.Contracts
{
    /// <summary>
    /// Interface for indexed resource managers.
    /// </summary>
    /// <typeparam name="T">The tpe of the indexed resouce. Must implement <see cref="IIndexedResource"/></typeparam>
    public interface IIndexedResourceManager<T> : IDictionary<int, T>
        where T : IIndexedResource
    {
        /// <summary>
        /// Gets or sets the zero-based index that will be assigned to the next created resource.
        /// </summary>
        int NextIndex { get; set; }

        /// <summary>
        /// Adds a new resource.
        /// </summary>
        /// <returns>Returns a new resource with an auto-assigned index and name.</returns>
        T Add();
    }
}
