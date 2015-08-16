namespace GameCreator.Contracts.Services
{
    /// <summary>
    /// Interface for a service that can load and save projects.
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// Loads a project from the given location.
        /// </summary>
        /// <param name="project">The empty project to populate.</param>
        /// <param name="type">The type of project to load.</param>
        /// <param name="location">The location to load the project from.</param>
        void LoadProject(IProject project, IProjectType type, string location);

        /// <summary>
        /// Saves a project to the given location.
        /// </summary>
        /// <param name="project">The project to save.</param>
        /// <param name="type">The type of project to save to.</param>
        /// <param name="location">The location to save the project to.</param>
        void SaveProject(IProject project, IProjectType type, string location);
    }
}
