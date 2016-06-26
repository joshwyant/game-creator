using App.Contracts;
using System.Collections.Generic;

namespace App.Resources
{
    public class AppSprite : NamedResource, IAppSprite
    {
        public override string DefaultPrefix { get { return "sprite"; } }

        public int BoundingBoxBottom { get; set; }
        public int BoundingBoxLeft { get; set; }
        public BoundingBoxMode BoundingBoxMode { get; set; }
        public int BoundingBoxRight { get; set; }
        public int BoundingBoxTop { get; set; }
        public int Height { get; set; }
        public bool LoadOnlyOnUse { get; set; }
        public int NextSubImage { get; set; }
        public bool PreciseCollisionChecking { get; set; }
        public bool PreloadTexture { get; set; }
        public bool SmoothEdges { get; set; }
        public Dictionary<int, byte[]> SubImages { get; set; }
        public bool IsTransparent { get; set; }
        public bool UseVideoMemory { get; set; }
        public int Width { get; set; }
        public int XOrigin { get; set; }
        public int YOrigin { get; set; }
    }
}
