using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Contracts
{
    public struct RoomBackground
    {
        public bool VisibleWhenRoomStarts;
        public bool ForegroundImage;
        public int BackgroundImageIndex;
        public int X;
        public int Y;
        public bool TileHorizontally;
        public bool TileVertically;
        public int HorizontalSpeed;
        public int VerticalSpeed;
        public bool Stretch;
    }
}
