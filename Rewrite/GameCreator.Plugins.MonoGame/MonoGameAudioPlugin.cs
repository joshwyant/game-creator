using GameCreator.Engine;

namespace GameCreator.Plugins.MonoGame
{
    internal sealed class MonoGameAudioPlugin : IAudioPlugin
    {
        private GameCreatorXnaGame Game { get; }

        public MonoGameAudioPlugin(GameCreatorXnaGame game)
        {
            Game = game;
        }
    }
}