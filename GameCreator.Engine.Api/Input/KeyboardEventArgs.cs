using System;
using GameCreator.Engine.Common;

namespace GameCreator.Api.Engine
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