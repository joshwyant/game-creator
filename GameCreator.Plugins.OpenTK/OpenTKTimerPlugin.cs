using GameCreator.Api.Engine;

namespace GameCreator.Plugins.OpenTK
{
    internal sealed class OpenTKTimerPlugin : ITimerPlugin
    {
        private GameCreatorOpenTKGameWindow Game { get; }
        
        public OpenTKTimerPlugin(GameCreatorOpenTKGameWindow game)
        {
            Game = game;
        }

        public double Fps => Game.UpdateFrequency;

        public double TargetFps
        {
            get => Game.UpdateFrequency;
            set => Game.UpdateFrequency = value;
        }
        public void Sleep(int ms)
        {
            Game.SleepTime = ms / 1000.0;
        }
    }
}