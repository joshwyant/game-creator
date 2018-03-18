namespace GameCreator.Engine
{
    public interface IGameContext
    {
        GameInstance OtherInstance { get; }
        GameRoom CurrentRoom { get; set; }
        IndexedResourceManager<GameInstance> Instances { get; }
        IndexedResourceManager<GameObject> Objects { get; }
        IndexedResourceManager<GameRoom> Rooms { get; }
        IndexedResourceManager<GameSprite> Sprites { get; }
        IndexedResourceManager<ITrigger> Triggers { get; }
        IGraphicsPlugin Graphics { get; }
        IInputPlugin Input { get; }
        IAudioPlugin Audio { get; }
        ITimerPlugin Timer { get; }
        int GameId { get; }
        [Gml("instance_create")] GameInstance CreateInstance(double x, double y, GameObject assignedObject);
        void Run();
    }
}