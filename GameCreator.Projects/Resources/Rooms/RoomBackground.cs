namespace GameCreator.Projects
{
    public class RoomBackground
    {
        public bool VisibleWhenRoomStarts { get; set; }
        public bool ForegroundImage { get; set; }
        public int BackgroundImageIndex { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool TileHorizontally { get; set; }
        public bool TileVertically { get; set; }
        public int HorizontalSpeed { get; set; }
        public int VerticalSpeed { get; set; }
        public bool Stretch { get; set; }
    }
}