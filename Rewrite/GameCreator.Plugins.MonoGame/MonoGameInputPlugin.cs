using GameCreator.Engine;
using GameCreator.Engine.Api;
using GameCreator.Engine.Common;
using Microsoft.Xna.Framework.Input;

namespace GameCreator.Plugins.MonoGame
{
    internal sealed class MonoGameInputPlugin : IInputPlugin
    {
        private GameCreatorXnaGame Game { get; }

        public MonoGameInputPlugin(GameCreatorXnaGame game)
        {
            Game = game;
            
            Game.KeyPressed += Game_KeyPressed;
        }

        private void Game_KeyPressed(Keys key)
        {
            KeyPress?.Invoke(this, new KeyboardEventArgs(KeyMapper.GetMap(key)));
        }

        public bool CheckKeyPressed(VirtualKeyCode key)
        {
            return Game.KeyboardState.IsKeyDown(KeyMapper.GetMap(key));
        }

        public event KeyboardEventHandler KeyPress;
    }
}