using System;
using System.IO;
using GameCreator.Engine;

namespace TestGame
{
    public class TestGame : GameContext
    {
        public TestGame(IGraphicsPlugin graphics, IInputPlugin input, IAudioPlugin audio, 
            ITimerPlugin timer, IResourceContext resourceContext)
            : base(graphics, input, audio, timer, resourceContext)
        {
            timer.TargetFps = 30;
        }

        public override int GameId => 54321;
    }
}