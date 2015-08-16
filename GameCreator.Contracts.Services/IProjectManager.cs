using System.Collections.Generic;

namespace GameCreator.Contracts.Services
{
    /// <summary>
    /// Interface for managing projects.
    /// </summary>
    public interface IProjectManager
    {
        /// <summary>
        /// Gets or sets the available project services.
        /// </summary>
        IEnumerable<IProjectService> ProjectServices { get; set; }

        /// <summary>
        /// Gets or sets the current project.
        /// </summary>
        IProject CurrentProject { get; set; }
    }
}
