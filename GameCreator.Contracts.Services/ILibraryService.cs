using System.Collections.Generic;

namespace GameCreator.Contracts.Services
{
    /// <summary>
    /// Interface for a service that provides a library.
    /// </summary>
    public interface ILibraryService
    {
        /// <summary>
        /// Gets the resources supported by the library.
        /// </summary>
        /// <returns>An enumerable of <see cref="ILibraryResource"/> representing the resources supported by the library.</returns>
        IEnumerable<ILibraryResource> GetSupportedResources();
    }
}
