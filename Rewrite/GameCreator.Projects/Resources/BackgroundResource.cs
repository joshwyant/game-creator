namespace GameCreator.Projects
{
    public class BackgroundResource : BaseResource
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int IsTransparent { get; set; }
        public bool UseVideoMemory { get; set; }
        public bool LoadOnlyOnUse { get; set; }
        public bool SmoothEdges { get; set; }
        public bool PreloadTexture { get; set; }
        public bool UseAsTileset { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int HorizontalOffset { get; set; }
        public int VerticalOffset { get; set; }
        public int HorizontalSeparation { get; set; }
        public int VerticalSeparation { get; set; }
        public byte[] Data { get; set; }
    }
}