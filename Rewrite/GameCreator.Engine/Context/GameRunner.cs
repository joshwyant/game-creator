using System;
using Ninject;

namespace GameCreator.Engine
{
    public sealed class GameRunner : IDisposable
    {
        private StandardKernel _kernel;
        private GameContext _game;

        public GameRunner()
        {
            _kernel = new StandardKernel();
            _kernel.Load("*.dll");
            _game = _kernel.Get<GameContext>();
        }
        
        public void Run()
        {
            _game.Run();
        }

        public void Dispose()
        {
            _kernel?.Dispose();
        }
    }
}