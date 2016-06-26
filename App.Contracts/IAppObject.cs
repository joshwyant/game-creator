using System.Collections.Generic;

namespace App.Contracts
{
    /// <summary>
    /// Interface for an object resource.
    /// </summary>
    public interface IAppObject : INamedIndexedResource
    {
        int Depth { get; set; }
        Dictionary<EventType, List<IAppObjectEvent>> Events { get; set; }
        int MaskSpriteIndex { get; set; }
        int Parent { get; set; }
        bool Persistent { get; set; }
        bool Solid { get; set; }
        int SpriteIndex { get; set; }
        bool Visible { get; set; }
    }
}
