using System.Collections.Generic;
using GameCreator.Resources.Api;

namespace GameCreator.Projects
{
    public class ObjectResource : BaseResource
    {
        public int SpriteIndex { get; set; }
        public bool Solid { get; set; }
        public bool Visible { get; set; }
        public int Depth { get; set; }
        public bool Persistent { get; set; }
        public int Parent { get; set; }
        public int MaskSpriteIndex { get; set; }
        public Dictionary<EventType, List<EventEntry>> Events { get; set; }
    }
}