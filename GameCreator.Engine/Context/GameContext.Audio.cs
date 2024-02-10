using GameCreator.Api.Engine;

namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        public IAudioPlugin Audio { get; }
    }
}