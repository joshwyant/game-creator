using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
string_char_at(str, index)	5.0	
clipboard_has_text()	5.0	
clipboard_get_text()	5.0	
clipboard_set_text(str)	5.0	
move_contact_solid(dir, maxdist)	5.0	
move_contact_all(dir, maxdist)	5.0	
move_outside_solid(dir, maxdist)	5.0	
move_outside_all(dir, maxdist)	5.0	
show_debug_message(str)	5.0	
keyboard_set_map(key1, key2)	5.0	
keyboard_get_map(key)	5.0	
keyboard_unset_map()	5.0	
keyboard_get_numlock()	5.0	
keyboard_set_numlock(on)	5.0	
keyboard_key_press(key)	5.0	
keyboard_key_release(key)	5.0	
joystick_name(id)	5.0	
joystick_axes(id)	5.0	
joystick_buttons(id)	5.0	
joystick_has_pov(id)	5.0	
joystick_rpos(id)	5.0	
joystick_upos(id)	5.0	
joystick_vpos(id)	5.0	
joystick_pov(id)	5.0	
set_cursor(cur)	5.0	
draw_text_sprite(x, y, string, sep, w, sprite, firstchar, scale)	5.0	
MCI_command(str)	5.0	
load_info(fname)	5.0	
message_size(w, h)	5.0	
highscore_show_ext(numb, back, border, col1, col2, name, size)	5.0	
highscore_add_current()	5.0	
draw_highscore(x1, y1, x2, y2)	5.0	
external_define(dll, name, calltype, restype, argnumb, arg1type, arg2type, …)	5.0	
external_call(id, arg1, arg2, …)	5.0	
draw_sprite_tiled(n, img, x, y)	5.0	
arctan2(y, x)	5.0	

Deprecated functions:
datafile_exists(ind)	5.0	5.3a
datafile_get_name(ind)	5.0	5.3a
datafile_get_filename(ind)	5.0	5.3a
datafile_export(ind, fname)	5.0	5.3a
datafile_discard(ind)	5.0	5.3a

*/

public interface IGMv50Functions
{
    #region Deprecated functions
    [Gml("datafile_exists", v50, v53a)]
    bool DatafileExists(int ind);

    [Gml("datafile_get_name", v50, v53a)]
    string DatafileGetName(int ind);

    [Gml("datafile_get_filename", v50, v53a)]
    string DatafileGetFilename(int ind);

    [Gml("datafile_export", v50, v53a)]
    void DatafileExport(int ind, string fname);

    [Gml("datafile_discard", v50, v53a)]
    void DatafileDiscard(int ind);
    #endregion

    [Gml("string_char_at", v50)]
    string StringCharAt(string str, int index);

    [Gml("clipboard_has_text", v50)]
    bool ClipboardHasText();

    [Gml("clipboard_get_text", v50)]
    string ClipboardGetText();

    [Gml("clipboard_set_text", v50)]
    void ClipboardSetText(string str);

    [Gml("move_contact_solid", v50)]
    bool MoveContactSolid(int dir, double maxdist);

    [Gml("move_contact_all", v50)]
    bool MoveContactAll(int dir, double maxdist);

    [Gml("move_outside_solid", v50)]
    bool MoveOutsideSolid(int dir, double maxdist);

    [Gml("move_outside_all", v50)]
    bool MoveOutsideAll(int dir, double maxdist);

    [Gml("show_debug_message", v50)]
    void ShowDebugMessage(string str);

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

    [Gml("joystick_name", v50)]
    string JoystickName(int id);

    [Gml("joystick_axes", v50)]
    int JoystickAxes(int id);

    [Gml("joystick_buttons", v50)]
    int JoystickButtons(int id);

    [Gml("joystick_has_pov", v50)]
    bool JoystickHasPov(int id);

    [Gml("joystick_rpos", v50)]
    double JoystickRpos(int id);

    [Gml("joystick_upos", v50)]
    double JoystickUpos(int id);

    [Gml("joystick_vpos", v50)]
    double JoystickVpos(int id);

    [Gml("joystick_pov", v50)]
    double JoystickPov(int id);

    [Gml("set_cursor", v50)]
    void SetCursor(int cur);

    [Gml("draw_text_sprite", v50)]
    void DrawTextSprite(double x, double y, string @string, int sep, double w, int sprite, int firstchar, double scale);

    [Gml("MCI_command", v50)]
    void MCICommand(string str);

    [Gml("load_info", v50)]
    void LoadInfo(string fname);

    [Gml("message_size", v50)]
    void MessageSize(double w, double h);

    [Gml("highscore_show_ext", v50)]
    void HighscoreShowExt(double numb, bool back, bool border, int col1, int col2, string name, double size);

    [Gml("highscore_add_current", v50)]
    void HighscoreAddCurrent();

    [Gml("draw_highscore", v50)]
    void DrawHighscore(double x1, double y1, double x2, double y2);

    [Gml("external_define", v50)]
    void ExternalDefine(string dll, string name, string calltype, string restype, int argnumb, string arg1type, string arg2type);

    [Gml("external_call", v50)]
    void ExternalCall(int id, string arg1, string arg2);

    [Gml("draw_sprite_tiled", v50)]
    void DrawSpriteTiled(int n, int img, double x, double y);

    [Gml("arctan2", v50)]
    double Arctan2(double y, double x);
}
