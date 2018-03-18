using GameCreator.Engine;

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