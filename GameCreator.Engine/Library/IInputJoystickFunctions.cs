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
    #endregion

}
