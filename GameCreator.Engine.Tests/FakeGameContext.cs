using GameCreator.Api.Engine;

namespace GameCreator.Engine.Tests
{
    public class FakeGameContext : GameContext
    {
        public FakeGameContext(IGraphicsPlugin graphics, IInputPlugin input, IAudioPlugin audio, 
            ITimerPlugin timer, IResourceContext resources) 
            : base(graphics, input, audio, timer, resources)
        {
        }

        public override int GameId => 1234;
    }
}