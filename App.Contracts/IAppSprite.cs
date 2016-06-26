using System.Collections.Generic;

namespace App.Contracts
{
    /// <summary>
    /// Interface for a sprite resource.
    /// </summary>
    public interface IAppSprite : INamedIndexedResource
    {
        int BoundingBoxBottom { get; set; }
        int BoundingBoxLeft { get; set; }
        BoundingBoxMode BoundingBoxMode { get; set; }
        int BoundingBoxRight { get; set; }
        int BoundingBoxTop { get; set; }
        int Height { get; set; }
        bool LoadOnlyOnUse { get; set; }
        int NextSubImage { get; set; }
        bool PreciseCollisionChecking { get; set; }
        bool PreloadTexture { get; set; }
        bool SmoothEdges { get; set; }
        Dictionary<int, byte[]> SubImages { get; set; }
        bool IsTransparent { get; set; }
        bool UseVideoMemory { get; set; }
        int Width { get; set; }
        int XOrigin { get; set; }
        int YOrigin { get; set; }
    }
}
