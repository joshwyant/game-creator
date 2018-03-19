using System.Collections.Generic;

namespace GameCreator.Engine
{
    public interface IResourceContext
    {
        int NextRoomId { get; }
        int NextObjectId { get; }
        int NextInstanceId { get; }
        int NextSpriteId { get; }
        IList<GameRoom> GetPredefinedRooms(GameContext context);
        IList<GameObject> GetPredefinedObjects(GameContext context);
        IList<GameSprite> GetPredefinedSprites(GameContext context);
        IList<ITrigger> GetPredefinedTriggers(GameContext gameContext);
    }
}