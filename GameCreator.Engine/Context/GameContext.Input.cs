using System.Collections.Generic;
using GameCreator.Api.Engine;
using GameCreator.Engine.Common;

namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        public IInputPlugin Input { get; }
        private Queue<VirtualKeyCode> KeysPressed = new Queue<VirtualKeyCode>();
        private HashSet<VirtualKeyCode> KeysDown = new HashSet<VirtualKeyCode>();

        private void Input_KeyPress(object sender, KeyboardEventArgs e)
        {
            KeysDown.Add(e.KeyCode);
            KeysPressed.Enqueue(e.KeyCode);
        }
    }
}