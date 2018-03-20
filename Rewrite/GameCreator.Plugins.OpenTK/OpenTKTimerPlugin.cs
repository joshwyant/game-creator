using GameCreator.Engine;
using GameCreator.Engine.Api;

namespace GameCreator.Plugins.OpenTK
{
    internal sealed class OpenTKTimerPlugin : ITimerPlugin
    {
        private GameCreatorOpenTKGameWindow Game { get; }
        
        public OpenTKTimerPlugin(GameCreatorOpenTKGameWindow game)
        {
            Game = game;
        }

        public double Fps => Game.RenderFrequency;

        public double TargetFps
        {
            get => Game.TargetRenderFrequency;
            set => Game.TargetRenderFrequency = value;
        }
        public void Sleep(int ms)
        {
            Game.SleepTime = ms / 1000.0;
        }
    }
}