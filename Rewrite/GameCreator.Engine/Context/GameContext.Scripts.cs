namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        public IndexedResourceManager<GameScript> Scripts { get; set; }
    }
}