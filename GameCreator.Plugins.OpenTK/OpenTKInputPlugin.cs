using GameCreator.Api.Engine;
using GameCreator.Engine.Common;
using OpenTK.Input;
using OpenTK.Windowing.Common;

namespace GameCreator.Plugins.OpenTK
{
    internal sealed class OpenTKInputPlugin : IInputPlugin
    {
        private GameCreatorOpenTKGameWindow GameWindow { get; }
        
        public OpenTKInputPlugin(GameCreatorOpenTKGameWindow gameWindow)
        {
            GameWindow = gameWindow;

            gameWindow.KeyDown += GameWindow_KeyDown;
        }

        void GameWindow_KeyDown(KeyboardKeyEventArgs e)
        {
            var key = KeyMapper.GetMap(e.Key);
            
            if (key == VirtualKeyCode.NoKey)
                return; // If there is no corresponding key mapping, we can't do anything about it.
            
            KeyPress?.Invoke(this, new KeyboardEventArgs(key));
        }

        public bool CheckKeyPressed(VirtualKeyCode keyCode)
        {
            var realKeyCode = KeyMapper.GetMap(keyCode);

            if (realKeyCode == 0)
            {
                return false;
            }

            return GameWindow.IsKeyDown(realKeyCode);
        }

        public event KeyboardEventHandler KeyPress;
    }
}