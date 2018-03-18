using GameCreator.Engine;

namespace GameCreator.Plugins.MonoGame
{
    internal sealed class MonoGameInputPlugin : IInputPlugin
    {
        private GameCreatorXnaGame Game { get; }

        public MonoGameInputPlugin(GameCreatorXnaGame game)
        {
            Game = game;
        }
    }
}