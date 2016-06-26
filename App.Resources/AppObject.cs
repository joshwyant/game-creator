using App.Contracts;
using System.Collections.Generic;

namespace App.Resources
{
    public class AppObject : NamedResource, IAppObject
    {
        public override string DefaultPrefix { get { return "object"; } }

        public int Depth { get; set; }
        public Dictionary<EventType, List<IAppObjectEvent>> Events { get; set; }
        public int MaskSpriteIndex { get; set; }
        public int Parent { get; set; }
        public bool Persistent { get; set; }
        public bool Solid { get; set; }
        public int SpriteIndex { get; set; }
        public bool Visible { get; set; }
    }
}
