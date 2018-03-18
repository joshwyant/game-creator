using System;
using GameCreator.Engine;

namespace GameCreator.Plugins.MonoGame
{
    public sealed class MonoGamePlugins : IDisposable
    {
        private readonly GameCreatorXnaGame _game;
        public IGraphicsPlugin Graphics { get; }
        public IAudioPlugin Audio { get; }
        public IInputPlugin Input { get; }
        public ITimerPlugin Timer { get; }

        public MonoGamePlugins()
        {
            _game = new GameCreatorXnaGame();
            Graphics = new MonoGameGraphicsPlugin(_game);
            Audio = new MonoGameAudioPlugin(_game);
            Input = new MonoGameInputPlugin(_game);
            Timer = new MonoGameTimerPlugin(_game);
        }

        public void Dispose()
        {
            _game?.Dispose();
        }
    }
}