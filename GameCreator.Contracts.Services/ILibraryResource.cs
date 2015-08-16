namespace GameCreator.Contracts.Services
{
    /// <summary>
    /// Interface for resources that are exported by a library.
    /// </summary>
    public interface ILibraryResource
    {
        /// <summary>
        /// Gets the type of the exported resource.
        /// </summary>
        LibraryResourceType ExportedType { get; }

        /// <summary>
        /// Gets the name of the exported resource.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the summary for the exported resource.
        /// </summary>
        string Summary { get; }
    }
}
