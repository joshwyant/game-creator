using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Contracts
{
    public struct RoomView
    {
        public bool VisibleWhenRoomStarts;
        public int Left;
        public int Top;
        public int Width;
        public int Height;
        public int X;
        public int Y;
        public int ViewportX;
        public int ViewportY;
        public int ViewportWidth;
        public int ViewportHeight;
        public int HorizontalBorder;
        public int VerticalBorder;
        public int HorizontalSpeed;
        public int VerticalSpeed;
        public int ObjectFollowing;
    }
}
