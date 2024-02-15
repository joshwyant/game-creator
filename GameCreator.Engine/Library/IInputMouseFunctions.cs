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
}
