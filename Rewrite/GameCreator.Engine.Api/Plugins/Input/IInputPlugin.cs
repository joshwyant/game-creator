using GameCreator.Engine.Common;

namespace GameCreator.Engine.Api
{
    public interface IInputPlugin
    {
        bool CheckKeyPressed(VirtualKeyCode keyCode);
        event KeyboardEventHandler KeyPress;
    }
}