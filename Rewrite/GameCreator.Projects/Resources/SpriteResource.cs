using System.Collections.Generic;
using GameCreator.Resources.Api;

namespace GameCreator.Projects
{
    public class SpriteResource : BaseResource
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int BoundingBoxLeft { get; set; }
        public int BoundingBoxRight { get; set; }
        public int BoundingBoxBottom { get; set; }
        public int BoundingBoxTop { get; set; }
        public bool IsTransparent { get; set; }
        public bool SmoothEdges { get; set; }
        public bool PreloadTexture { get; set; }
        public BoundingBoxFunction BoundingBoxFunction { get; set; }
        public bool PreciseCollisionChecking { get; set; }
        public bool UseVideoMemory { get; set; }
        public bool LoadOnlyOnUse { get; set; }
        public int XOrigin { get; set; }
        public int YOrigin { get; set; }
        public List<byte[]> SubImages { get; set; }
    }
}