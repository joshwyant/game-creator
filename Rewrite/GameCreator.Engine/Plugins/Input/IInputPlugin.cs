using System.Collections.Generic;
using GameCreator.Core;

namespace GameCreator.Engine
{
    public interface IInputPlugin
    {
        bool CheckKeyPressed(VirtualKeyCode keyCode);
        event KeyboardEventHandler KeyPress;
    }
}