using App.Contracts;

namespace App.Resources
{
    public class AppBackground : NamedResource, IAppBackground
    {
        public override string DefaultPrefix { get { return "background"; } }

        public byte[] Data { get; set; }
        public int Height { get; set; }
        public int HorizontalOffset { get; set; }
        public int HorizontalSeparation { get; set; }
        public int IsTransparent { get; set; }
        public bool LoadOnlyOnUse { get; set; }
        public bool PreloadTexture { get; set; }
        public bool SmoothEdges { get; set; }
        public int TileHeight { get; set; }
        public int TileWidth { get; set; }
        public bool UseAsTileset { get; set; }
        public bool UseVideoMemory { get; set; }
        public int VerticalOffset { get; set; }
        public int VerticalSeparation { get; set; }
        public int Width { get; set; }
    }
}
