using GameCreator.Resources.Api;

namespace GameCreator.Projects
{
    public class TileResource : IIndexedResource
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int BackgroundIndex { get; set; }
        public int TileX { get; set; }
        public int TileY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Layer { get; set; }
        public bool Locked { get; set; }
    }
}