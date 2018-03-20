using System;
using GameCreator.Engine;
using GameCreator.Engine.Api;

namespace GameCreator.Plugins.MonoGame
{
    internal sealed class MonoGameTimerPlugin : ITimerPlugin
    {
        private GameCreatorXnaGame Game { get; }

        public MonoGameTimerPlugin(GameCreatorXnaGame game)
        {
            Game = game;
        }
        
        public double Fps => Game.Fps;

        public double TargetFps
        {
            get => 1.0 / Game.TargetElapsedTime.TotalSeconds;
            set => Game.TargetElapsedTime = TimeSpan.FromSeconds(1.0 / value);
        }

        public void Sleep(int ms)
        {
            Game.SleepTime += ms / 1000.0;
        }
    }
}