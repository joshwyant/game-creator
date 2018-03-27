using System;
using GameCreator.Engine.Common;

namespace GameCreator.Engine.Api
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