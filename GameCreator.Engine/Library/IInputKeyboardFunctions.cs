using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IInputKeyboardFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v1.4
    //
    [Gml("check_key", v14, v33)]
    bool CheckKey(int keycode);

    //
    // Introduced in v3.3
    //
    [Gml("check_key_direct", v33, v33)]
    bool CheckKeyDirect(int keycode);
    #endregion

}
