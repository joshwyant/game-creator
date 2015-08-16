using System.Collections.Generic;

namespace GameCreator.Contracts.Services
{
    /// <summary>
    /// Interface for managing output targets.
    /// </summary>
    public interface ITargetManager
    {
        /// <summary>
        /// Gets or sets the available target services.
        /// </summary>
        IEnumerable<ITargetService> TargetServices { get; set; }
    }
}
