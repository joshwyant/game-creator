namespace GameCreator.Contracts.Services
{
    /// <summary>
    /// Interface for a service that can export a project to a specific binary target.
    /// </summary>
    public interface ITargetService
    {
        /// <summary>
        /// Gets the description for the target that this service supports
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Compiles a binary for the given project.
        /// </summary>
        /// <param name="project">The project to compile.</param>
        /// <param name="dir">The output directory.</param>
        /// <param name="name">The name of the output binary.</param>
        void Compile(IProject project, string dir, string name);

        /// <summary>
        /// Gets the library service representing the resources exported by the target library.
        /// </summary>
        ILibraryService LibraryService { get; }
    }
}
