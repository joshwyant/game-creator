using GameCreator.Engine;
using GameCreator.Engine.Api;

namespace GameCreator.Plugins.OpenTK
{
    internal sealed class OpenTKAudioPlugin : IAudioPlugin
    {
        private GameCreatorOpenTKGameWindow GameWindow { get; }
        
        public OpenTKAudioPlugin(GameCreatorOpenTKGameWindow gameWindow)
        {
            GameWindow = gameWindow;
        }
    }
}