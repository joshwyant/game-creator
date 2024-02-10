using GameCreator.Api.Resources;

namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        public IndexedResourceManager<GameBackground> Backgrounds { get; set; }
    }
}