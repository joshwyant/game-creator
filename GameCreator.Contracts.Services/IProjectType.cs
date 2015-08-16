using System.Collections.Generic;

namespace GameCreator.Contracts.Services
{
    /// <summary>
    /// Interface for a type of project.
    /// </summary>
    public interface IProjectType
    {
        /// <summary>
        /// Gets whether the project is persisted as a standalone file, as opposed to a project directory.
        /// </summary>
        bool IsSingleFile { get; }

        /// <summary>
        /// Gets the file extension associated with the main project file.
        /// </summary>
        string Extension { get; }

        /// <summary>
        /// Gets the description for this project type.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the versions that this project type can handle.
        /// </summary>
        IEnumerable<GmVersion> Versions { get; }
    }
}
