using GameCreator.Engine.Common;

namespace GameCreator.Api.Engine
{
    public interface IInputPlugin
    {
        bool CheckKeyPressed(VirtualKeyCode keyCode);
        event KeyboardEventHandler KeyPress;
    }
}