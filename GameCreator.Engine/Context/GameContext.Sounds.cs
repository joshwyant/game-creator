using GameCreator.Api.Resources;

namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        public IndexedResourceManager<GameSound> Sounds { get; }
    }
}