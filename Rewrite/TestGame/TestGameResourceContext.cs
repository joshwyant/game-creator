using System.Collections.Generic;
using GameCreator.Engine;

namespace TestGame
{
    public class TestGameResourceContext : IResourceContext
    {
        public int NextRoomId => -1;
        public int NextObjectId => -1;
        public int NextInstanceId => -1;
        public IList<GameRoom> GetPredefinedRooms(IGameContext context)
        {
            return new GameRoom[0];
        }

        public IList<GameObject> GetPredefinedObjects(IGameContext context)
        {
            return new GameObject[0];
        }

        public IList<ITrigger> GetPredefinedTriggers(IGameContext gameContext)
        {
            return new ITrigger[0];
        }
    }
}