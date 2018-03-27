using System;
using System.Collections.Generic;
using GameCreator.Resources.Api;

namespace GameCreator.Projects
{
    public class SpriteResource : BaseResource
    {
        [Obsolete] public int Width { get; set; }
        [Obsolete] public int Height { get; set; }
        public int BoundingBoxLeft { get; set; }
        public int BoundingBoxRight { get; set; }
        public int BoundingBoxBottom { get; set; }
        public int BoundingBoxTop { get; set; }
        public bool IsTransparent { get; set; }
        [Obsolete] public bool SmoothEdges { get; set; }
        [Obsolete] public bool PreloadTexture { get; set; }
        public BoundingBoxFunction BoundingBoxFunction { get; set; }
        [Obsolete] public bool PreciseCollisionChecking { get; set; }
        [Obsolete] public bool UseVideoMemory { get; set; }
        [Obsolete] public bool LoadOnlyOnUse { get; set; }
        public int XOrigin { get; set; }
        public int YOrigin { get; set; }
        public List<SubImage> SubImages { get; set; }
        public int Version { get; set; }
        public DateTime LastModified { get; set; }
        public CollisionMaskFunction Shape { get; set; }
        public int AlphaTolerance { get; set; }
        public bool SeparateCollisionMasks { get; set; }
    }
}