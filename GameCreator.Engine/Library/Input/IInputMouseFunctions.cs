using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IInputMouseFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v2.0
    //
    [Gml("check_mouse_button", v20, v33)]
    bool CheckMouseButton(int numb);
    #endregion

    //
    // Introduced in v4.0
    //
    [Gml("mouse_clear", v40)]
    void MouseClear(double button);

    //
    // Introduced in v5.1
    //
    [Gml("mouse_wait", v51)]
    void MouseWait();

    //
    // 6.0
    //
    [Gml("mouse_check_button_pressed", v60)]
    bool MouseCheckButtonPressed(int numb);

    [Gml("mouse_check_button_released", v60)]
    bool MouseCheckButtonReleased(int numb);

    //
    // 8.0
    //
    [Gml("mouse_wheel_down", v80)]
    bool MouseWheelDown();

    [Gml("mouse_wheel_up", v80)]
    bool MouseWheelUp();
}
