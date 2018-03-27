using System;

namespace GameCreator.Projects
{
    public class RoomView
    {
        public bool VisibleWhenRoomStarts { get; set; }
        [Obsolete] public int Left { get; set; }
        [Obsolete] public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int ViewportX { get; set; }
        public int ViewportY { get; set; }
        public int ViewportWidth { get; set; }
        public int ViewportHeight { get; set; }
        public int HorizontalBorder { get; set; }
        public int VerticalBorder { get; set; }
        public int HorizontalSpeed { get; set; }
        public int VerticalSpeed { get; set; }
        public int ObjectFollowing { get; set; }
    }
}