using System;
using GameCreator.Core;

namespace GameCreator.Engine
{
    public delegate void KeyboardEventHandler (object sender, KeyboardEventArgs e);
    
    public class KeyboardEventArgs : EventArgs
    {
        public KeyboardEventArgs(VirtualKeyCode keyCode)
        {
            KeyCode = keyCode;
        }
        
        public VirtualKeyCode KeyCode { get; set; }
    }
}