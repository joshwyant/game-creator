using System.Collections.Generic;
using static GameCreator.Engine.Library.MoveDirections;

namespace GameCreator.Engine.Library
{
    public partial class ActionLibrary : IActionLibrary
    {
        public GameContext Context { get; }
        private static readonly Dictionary<MoveDirections, int> MoveDirections = new Dictionary<MoveDirections, int>
        {
            { NorthWest, 135 }, { North, 90 }, { NorthEast, 45 },
            { West, 180 }, { East, 0 },
            { SouthWest, 225 }, { South, 270 }, { SouthEast, 315 }
        };

        public ActionLibrary(GameContext context)
        {
            Context = context;
        }
    }
}