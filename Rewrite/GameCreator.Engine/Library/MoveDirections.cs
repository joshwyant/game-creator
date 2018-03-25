using System;

namespace GameCreator.Engine.Library
{
    [Flags]
    public enum MoveDirections
    {
        NotSet = 0,
        SouthWest = 1 << 0,
        South = 1 << 1,
        SouthEast = 1 << 2,
        West = 1 << 3,
        Stop = 1 << 4,
        East = 1 << 5,
        NorthWest = 1 << 6,
        North = 1 << 7,
        NorthEast = 1 << 8
    }
}