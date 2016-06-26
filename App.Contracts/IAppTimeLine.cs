using System.Collections.Generic;

namespace App.Contracts
{
    /// <summary>
    /// Interface for a timeline resource.
    /// </summary>
    public interface IAppTimeline : INamedIndexedResource
    {
        Dictionary<int, List<IAppAction>> Moments { get; set; }
    }
}
