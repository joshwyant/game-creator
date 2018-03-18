using System;
using Ninject;
using Ninject.Modules;

namespace GameCreator.Engine
{
    public sealed class GameRunner : IDisposable
    {
        private StandardKernel _kernel;
        private IGameContext _game;

        public GameRunner()
        {
            _kernel = new StandardKernel();
            _kernel.Load("*.dll");
            _game = _kernel.Get<IGameContext>();
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