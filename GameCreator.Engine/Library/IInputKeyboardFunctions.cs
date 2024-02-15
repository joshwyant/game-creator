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

    //
    // Introduced in v4.0
    //
    [Gml("keyboard_check", v40)]
    double KeyboardCheck(double key);

    [Gml("keyboard_check_direct", v40)]
    double KeyboardCheckDirect(double key);

    [Gml("mouse_check_button", v40)]
    double MouseCheckButton(double numb);

    [Gml("keyboard_clear", v40)]
    void KeyboardClear(double key);

    [Gml("io_clear", v40)]
    void IoClear();

    [Gml("io_handle", v40)]
    void IoHandle();

    [Gml("keyboard_wait", v40)]
    void KeyboardWait();

    //
    // Introduced in v5.0
    //

    [Gml("keyboard_set_map", v50)]
    void KeyboardSetMap(int key1, int key2);

    [Gml("keyboard_get_map", v50)]
    int KeyboardGetMap(int key);

    [Gml("keyboard_unset_map", v50)]
    void KeyboardUnsetMap();

    [Gml("keyboard_get_numlock", v50)]
    bool KeyboardGetNumlock();

    [Gml("keyboard_set_numlock", v50)]
    void KeyboardSetNumlock(bool on);

    [Gml("keyboard_key_press", v50)]
    void KeyboardKeyPress(int key);

    [Gml("keyboard_key_release", v50)]
    void KeyboardKeyRelease(int key);
}
