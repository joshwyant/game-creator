using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Contracts
{
    public struct RoomTile
    {
        public int X;
        public int Y;
        public int BackgroundIndex;
        public int TileX;
        public int TileY;
        public int Width;
        public int Height;
        public int Layer;
        public int ID;
        public bool Locked;
    }
}
