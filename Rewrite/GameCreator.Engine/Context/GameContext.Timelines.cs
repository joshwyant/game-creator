namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        public IndexedResourceManager<GameTimeline> Timelines { get; set; }
    }
}