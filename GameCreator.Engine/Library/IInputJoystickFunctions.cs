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

    //
    // Introduced in v4.0
    //
    [Gml("joystick_exists", v40)]
    double JoystickExists(double id);

    [Gml("joystick_direction", v40)]
    double JoystickDirection(double id);

    [Gml("joystick_check_button", v40)]
    double JoystickCheckButton(double id, double numb);

    [Gml("joystick_xpos", v40)]
    double JoystickXpos(double id);

    [Gml("joystick_ypos", v40)]
    double JoystickYpos(double id);

    [Gml("joystick_zpos", v40)]
    double JoystickZpos(double id);
}
