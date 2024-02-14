using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
get_open_filename(filter, fname)	4.0
get_save_filename(filter, fname)	4.0
get_directory(dname)	4.0
get_color(defcolor)	4.0
real(str)	4.0
string_format(val, tot, dec)	4.0
draw_button(x1, y1, x2, y2, up)	4.0
motion_set(dir, speed)	4.0
motion_add(dir, speed)	4.0
place_free(x, y)	4.0
place_empty(x, y)	4.0
place_meeting(x, y, obj)	4.0
place_snapped(hsnap, vsnap)	4.0
move_random(hsnap, vsnap)	4.0
move_snap(hsnap, vsnap)	4.0
move_towards_point(x, y, sp)	4.0
move_bounce_solid(adv)	4.0
move_bounce_all(adv)	4.0
move_contact(dir)	4.0
position_empty(x, y)	4.0
position_meeting(x, y, obj)	4.0
instance_find(obj, n)	4.0
instance_exists(obj)	4.0
instance_number(obj)	4.0
instance_position(x, y, obj)	4.0
instance_nearest(x, y, obj)	4.0
instance_furthest(x, y, obj)	4.0
instance_place(x, y, obj)	4.0
instance_create(x, y, obj)	4.0
instance_destroy()	4.0
instance_change(obj, perf)	4.0
position_destroy(x, y)	4.0
position_change(x, y, obj, perf)	4.0
room_goto(numb)	4.0
room_goto_previous()	4.0
room_goto_next()	4.0
room_restart()	4.0
room_previous(numb)	4.0
room_next(numb)	4.0
game_end()	4.0
game_restart()	4.0
game_save(string)	4.0
game_load(string)	4.0
event_perform(type, numb)	4.0
event_perform_object(obj, type, numb)	4.0
event_user(numb)	4.0
keyboard_check(key)	4.0
keyboard_check_direct(key)	4.0
mouse_check_button(numb)	4.0
keyboard_clear(key)	4.0
mouse_clear(button)	4.0
io_clear()	4.0
io_handle()	4.0
keyboard_wait()	4.0
joystick_exists(id)	4.0
joystick_direction(id)	4.0
joystick_check_button(id, numb)	4.0
joystick_xpos(id)	4.0
joystick_ypos(id)	4.0
joystick_zpos(id)	4.0
sprite_discard(numb)	4.0
sprite_restore(numb)	4.0
discard_all()	4.0
background_discard(numb)	4.0
background_restore(numb)	4.0
draw_sprite(n, img, x, y)	4.0
draw_sprite_scaled(n, img, x, y, s)	4.0
draw_sprite_stretched(n, img, x, y, w, h)	4.0
draw_background(n, x, y)	4.0
draw_background_scaled(n, x, y, s)	4.0
draw_background_stretched(n, x, y, s, alpha)	4.0
draw_background_tiled(n, x, y)	4.0
screen_save(fname)	4.0
screen_save_part(fname, left, top, right, bottom)	4.0
screen_redraw()	4.0
screen_refresh()	4.0
sound_isplaying(index)	4.0
sound_discard(index)	4.0
sound_restore(index)	4.0
show_menu(str, def)	4.0
directory_exists(dname)	4.0
directory_create(dname)	4.0
registry_write_string(name, str)	4.0
registry_write_real(name, x)	4.0
registry_read_string(name)	4.0
registry_read_real(name)	4.0
registry_exists(name)	4.0
registry_read_string_ext(key, name)	4.0
registry_read_real_ext(key, name)	4.0
registry_exists_ext(key, name)	4.0
execute_program(prog, arg, wait)	4.0
execute_shell(prog, arg)	4.0
external_define0(dll, name, restype)	4.0
external_define1(dll, name, arg1type, restype)	4.0
external_define2(dll, name, arg1type, arg2type, restype)	4.0
make_color(red, green, blue)	4.0

Deprecated functions:
background_replace(ind, fname)	4.0	4.0
external_call0(id)	4.0	4.3
external_call1(id)	4.0	4.3
external_call2(id)	4.0	4.3
draw_sprite_transparent(n, img, x, y, s, alpha)	4.0	5.0
draw_background_transparent(n, x, y, s, alpha)	4.0	5.0
draw_pixel(x, y)	4.0	5.3a
draw_fill(x, y)	4.0	5.3a
draw_arc(x1, y1, x2, y2, x3, y3, x4, y4)	4.0	5.3a
draw_chord(x1, y1, x2, y2, x3, y3, x4, y4)	4.0	5.3a
draw_pie(x1, y1, x2, y2, x3, y3, x4, y4)	4.0	5.3a
screen_gamma(r, g, b)	4.0	5.3a

*/

public interface IGMv40Functions
{
    #region Deprecated functions
    [Gml("background_replace", v40, v40)]
    void BackgroundReplace(int ind, string fname);

    [Gml("external_call0", v40, v43c)]
    void ExternalCall0(int id);

    [Gml("external_call1", v40, v43c)]
    void ExternalCall1(int id);

    [Gml("external_call2", v40, v43c)]
    void ExternalCall2(int id);

    [Gml("draw_sprite_transparent", v40, v50)]
    void DrawSpriteTransparent(int n, int img, double x, double y, double s, int alpha);

    [Gml("draw_background_transparent", v40, v50)]
    void DrawBackgroundTransparent(int n, double x, double y, double s, int alpha);

    [Gml("draw_pixel", v40, v53a)]
    void DrawPixel(double x, double y);

    [Gml("draw_fill", v40, v53a)]
    void DrawFill(double x, double y);

    [Gml("draw_arc", v40, v53a)]
    void DrawArc(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4);

    [Gml("draw_chord", v40, v53a)]
    void DrawChord(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4);

    [Gml("draw_pie", v40, v53a)]
    void DrawPie(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4);

    [Gml("screen_gamma", v40, v53a)]
    void ScreenGamma(int r, int g, int b);
    #endregion
    
    [Gml("get_open_filename", v40)]
    string GetOpenFilename(string filter, string fname);

    [Gml("get_save_filename", v40)]
    string GetSaveFilename(string filter, string fname);

    [Gml("get_directory", v40)]
    string GetDirectory(string dname);

    [Gml("get_color", v40)]
    double GetColor(double defcolor);

    [Gml("real", v40)]
    double Real(string str);

    [Gml("string_format", v40)]
    string StringFormat(double val, double tot, double dec);

    [Gml("draw_button", v40)]
    void DrawButton(double x1, double y1, double x2, double y2, double up);

    [Gml("motion_set", v40)]
    void MotionSet(double dir, double speed);

    [Gml("motion_add", v40)]
    void MotionAdd(double dir, double speed);

    [Gml("place_free", v40)]
    double PlaceFree(double x, double y);

    [Gml("place_empty", v40)]
    double PlaceEmpty(double x, double y);

    [Gml("place_meeting", v40)]
    double PlaceMeeting(double x, double y, string obj);

    [Gml("place_snapped", v40)]
    double PlaceSnapped(double hsnap, double vsnap);

    [Gml("move_random", v40)]
    void MoveRandom(double hsnap, double vsnap);

    [Gml("move_snap", v40)]
    void MoveSnap(double hsnap, double vsnap);

    [Gml("move_towards_point", v40)]
    void MoveTowardsPoint(double x, double y, double sp);

    [Gml("move_bounce_solid", v40)]
    void MoveBounceSolid(double adv);

    [Gml("move_bounce_all", v40)]
    void MoveBounceAll(double adv);

    [Gml("move_contact", v40)]
    void MoveContact(double dir);

    [Gml("position_empty", v40)]
    double PositionEmpty(double x, double y);

    [Gml("position_meeting", v40)]
    double PositionMeeting(double x, double y, string obj);

    [Gml("instance_find", v40)]
    double InstanceFind(string obj, double n);

    [Gml("instance_exists", v40)]
    double InstanceExists(string obj);

    [Gml("instance_number", v40)]
    double InstanceNumber(string obj);

    [Gml("instance_position", v40)]
    double InstancePosition(double x, double y, string obj);

    [Gml("instance_nearest", v40)]
    double InstanceNearest(double x, double y, string obj);

    [Gml("instance_furthest", v40)]
    double InstanceFurthest(double x, double y, string obj);

    [Gml("instance_place", v40)]
    double InstancePlace(double x, double y, string obj);

    [Gml("instance_create", v40)]
    double InstanceCreate(double x, double y, string obj);

    [Gml("instance_destroy", v40)]
    void InstanceDestroy();

    [Gml("instance_change", v40)]
    void InstanceChange(string obj, double perf);

    [Gml("position_destroy", v40)]
    void PositionDestroy(double x, double y);

    [Gml("position_change", v40)]
    void PositionChange(double x, double y, string obj, double perf);

    [Gml("room_goto", v40)]
    void RoomGoto(double numb);

    [Gml("room_goto_previous", v40)]
    void RoomGotoPrevious();

    [Gml("room_goto_next", v40)]
    void RoomGotoNext();

    [Gml("room_restart", v40)]
    void RoomRestart();

    [Gml("room_previous", v40)]
    void RoomPrevious(double numb);

    [Gml("room_next", v40)]
    void RoomNext(double numb);

    [Gml("game_end", v40)]
    void GameEnd();

    [Gml("game_restart", v40)]
    void GameRestart();

    [Gml("game_save", v40)]
    void GameSave(string @string);

    [Gml("game_load", v40)]
    void GameLoad(string @string);

    [Gml("event_perform", v40)]
    void EventPerform(double type, double numb);

    [Gml("event_perform_object", v40)]
    void EventPerformObject(string obj, double type, double numb);

    [Gml("event_user", v40)]
    void EventUser(double numb);

    [Gml("keyboard_check", v40)]
    double KeyboardCheck(double key);

    [Gml("keyboard_check_direct", v40)]
    double KeyboardCheckDirect(double key);

    [Gml("mouse_check_button", v40)]
    double MouseCheckButton(double numb);

    [Gml("keyboard_clear", v40)]
    void KeyboardClear(double key);

    [Gml("mouse_clear", v40)]
    void MouseClear(double button);

    [Gml("io_clear", v40)]
    void IoClear();

    [Gml("io_handle", v40)]
    void IoHandle();

    [Gml("keyboard_wait", v40)]
    void KeyboardWait();

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

    [Gml("sprite_discard", v40)]
    void SpriteDiscard(double numb);

    [Gml("sprite_restore", v40)]
    void SpriteRestore(double numb);

    [Gml("discard_all", v40)]
    void DiscardAll();

    [Gml("background_discard", v40)]
    void BackgroundDiscard(double numb);

    [Gml("background_restore", v40)]
    void BackgroundRestore(double numb);

    [Gml("draw_sprite", v40)]
    void DrawSprite(double n, double img, double x, double y);

    [Gml("draw_sprite_scaled", v40)]
    void DrawSpriteScaled(double n, double img, double x, double y, double s);

    [Gml("draw_sprite_stretched", v40)]
    void DrawSpriteStretched(double n, double img, double x, double y, double w, double h);

    [Gml("draw_background", v40)]
    void DrawBackground(double n, double x, double y);

    [Gml("draw_background_scaled", v40)]
    void DrawBackgroundScaled(double n, double x, double y, double s);

    [Gml("draw_background_stretched", v40)]
    void DrawBackgroundStretched(double n, double x, double y, double s, double alpha);

    [Gml("draw_background_tiled", v40)]
    void DrawBackgroundTiled(double n, double x, double y);

    [Gml("screen_save", v40)]
    void ScreenSave(string fname);

    [Gml("screen_save_part", v40)]
    void ScreenSavePart(string fname, double left, double top, double right, double bottom);

    [Gml("screen_redraw", v40)]
    void ScreenRedraw();

    [Gml("screen_refresh", v40)]
    void ScreenRefresh();

    [Gml("sound_isplaying", v40)]
    double SoundIsplaying(double index);

    [Gml("sound_discard", v40)]
    void SoundDiscard(double index);

    [Gml("sound_restore", v40)]
    void SoundRestore(double index);

    [Gml("show_menu", v40)]
    void ShowMenu(string str, double def);

    [Gml("directory_exists", v40)]
    double DirectoryExists(string dname);

    [Gml("directory_create", v40)]
    double DirectoryCreate(string dname);

    [Gml("registry_write_string", v40)]
    void RegistryWriteString(string name, string str);

    [Gml("registry_write_real", v40)]
    void RegistryWriteReal(string name, double x);

    [Gml("registry_read_string", v40)]
    string RegistryReadString(string name);

    [Gml("registry_read_real", v40)]
    double RegistryReadReal(string name);

    [Gml("registry_exists", v40)]
    double RegistryExists(string name);

    [Gml("registry_read_string_ext", v40)]
    string RegistryReadStringExt(string key, string name);

    [Gml("registry_read_real_ext", v40)]
    double RegistryReadRealExt(string key, string name);

    [Gml("registry_exists_ext", v40)]
    double RegistryExistsExt(string key, string name);

    [Gml("execute_program", v40)]
    double ExecuteProgram(string prog, string arg, double wait);

    [Gml("execute_shell", v40)]
    double ExecuteShell(string prog, string arg);

    [Gml("external_define0", v40)]
    double ExternalDefine0(string dll, string name, string restype);

    [Gml("external_define1", v40)]
    double ExternalDefine1(string dll, string name, string arg1type, string restype);

    [Gml("external_define2", v40)]
    double ExternalDefine2(string dll, string name, string arg1type, string arg2type, string restype);

    [Gml("make_color", v40)]
    double MakeColor(double red, double green, double blue);

}