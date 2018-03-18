using System.Collections.Generic;

namespace GameCreator.Engine
{
    public interface IResourceContext
    {
        int NextRoomId { get; }
        int NextObjectId { get; }
        int NextInstanceId { get; }
        int NextSpriteId { get; }
        IList<GameRoom> GetPredefinedRooms(IGameContext context);
        IList<GameObject> GetPredefinedObjects(IGameContext context);
        IList<GameSprite> GetPredefinedSprites(IGameContext context);
        IList<ITrigger> GetPredefinedTriggers(IGameContext gameContext);
    }
}