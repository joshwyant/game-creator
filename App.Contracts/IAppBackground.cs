namespace App.Contracts
{
    /// <summary>
    /// Interface for a background resource.
    /// </summary>
    public interface IAppBackground : INamedIndexedResource
    {
        byte[] Data { get; set; }
        int Height { get; set; }
        int HorizontalOffset { get; set; }
        int HorizontalSeparation { get; set; }
        int IsTransparent { get; set; }
        bool LoadOnlyOnUse { get; set; }
        bool PreloadTexture { get; set; }
        bool SmoothEdges { get; set; }
        int TileHeight { get; set; }
        int TileWidth { get; set; }
        bool UseAsTileset { get; set; }
        bool UseVideoMemory { get; set; }
        int VerticalOffset { get; set; }
        int VerticalSeparation { get; set; }
        int Width { get; set; }
    }
}
