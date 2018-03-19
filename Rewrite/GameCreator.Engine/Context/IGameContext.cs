namespace GameCreator.Engine
{
    public interface IGameContext
    {
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
        GameInstance OtherInstance { get; }
        bool Enable3dMode { get; }
        double DrawDepth3d { get; set; }
        [Gml("instance_create")] GameInstance CreateInstance(double x, double y, GameObject assignedObject);
        void Run();
        void ProcessEvents();
        void DrawScreen();
        void Start3dMode();
        void End3dMode();
        void SetProjectionPerspective(float x, float y, float w, float h, float angle);
    }
}