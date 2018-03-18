using GameCreator.Engine;

namespace GameCreator.Plugins.OpenTK
{
    internal sealed class OpenTKInputPlugin : IInputPlugin
    {
        private GameCreatorOpenTKGameWindow GameWindow { get; }
        
        public OpenTKInputPlugin(GameCreatorOpenTKGameWindow gameWindow)
        {
            GameWindow = gameWindow;
        }
    }
}