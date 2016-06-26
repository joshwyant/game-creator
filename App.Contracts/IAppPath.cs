using System;
using System.Collections.Generic;

namespace App.Contracts
{
    /// <summary>
    /// Interface for a path resource.
    /// </summary>
    public interface IAppPath : INamedIndexedResource
    {
        PathKind ConnectionKind { get; set; }
        bool IsClosed { get; set; }
        List<PathVertex> Points { get; set; }
        int Precision { get; set; }
        int RoomReference { get; set; }
        int SnapX { get; set; }
        int SnapY { get; set; }
    }
}
