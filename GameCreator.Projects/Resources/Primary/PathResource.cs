using System.Collections.Generic;

namespace GameCreator.Projects
{
    public class PathResource : BaseResource
    {
        public bool IsSmooth { get; set; }
        public bool IsClosed { get; set; }
        public int Precision { get; set; }
        public int RoomReference { get; set; }
        public int SnapX { get; set; }
        public int SnapY { get; set; }
        public List<PathVertex> Points { get; set; }
    }
}