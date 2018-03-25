namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        public IndexedResourceManager<GamePath> Paths { get; set; }
    }
}