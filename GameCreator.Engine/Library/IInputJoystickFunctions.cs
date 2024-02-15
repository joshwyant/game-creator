using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IInputJoystickFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v2.0
    //
    [Gml("check_joystick_direction", v20, v33)]
    bool CheckJoystickDirection();

    [Gml("check_joystick_button", v20, v33)]
    bool CheckJoystickButton(int numb);

    //
    // Introduced in v3.1
    //
    [Gml("get_joystick_xpos", v31, v33)]
    double GetJoystickXpos();

    [Gml("get_joystick_ypos", v31, v33)]
    double GetJoystickYpos();

    [Gml("get_joystick_zpos", v31, v33)]
    double GetJoystickZpos();
    #endregion

}
