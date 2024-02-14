using GameCreator.Api.Engine;

namespace GameCreator.Engine.Library;

public interface DeprecatedFunctions
{
    [Gml("sound", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v14)]
    void Sound(int numb);
    [Gml("show_highscore", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v14)]
    void ShowHighscore(int numb);
    [Gml("write", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v20)]
    void Write(int ind, double x);
    [Gml("read", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v20)]
    double Read(int ind);
    [Gml("goto_room", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v33)]
    void GotoRoom(int numb);
    [Gml("create", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v33)]
    void Create(double x, double y, int obj);
    [Gml("change", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v33)]
    void Change(int obj1, int obj2);
    [Gml("change_at", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v33)]
    void ChangeAt(double x, double y, int obj);
    [Gml("destroy", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v33)]
    void Destroy(int obj);
    [Gml("destroy_at", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v33)]
    void DestroyAt(double x, double y);
    [Gml("is_free", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v33)]
    bool IsFree(double x, double y);
    [Gml("is_empty", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v33)]
    bool IsEmpty(double x, double y);
    [Gml("is_meeting", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v33)]
    bool IsMeeting(double x, double y, int obj);
    [Gml("number", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v33)]
    int Number(int obj);
    [Gml("move_random", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v33)]
    void MoveRandom(int obj);
    [Gml("end_game", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v33)]
    void EndGame();
    [Gml("redraw", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v33)]
    void Redraw();
    [Gml("set_gamespeed", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v33)]
    void SetGamespeed(int numb);
    [Gml("min", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v52)]
    double Min(double x, double y);
    [Gml("max", minVersion: GameMakerVersion.v11, maxVersion: GameMakerVersion.v52)]
    double Max(double x, double y);
    [Gml("nothing_at", minVersion: GameMakerVersion.v12, maxVersion: GameMakerVersion.v33)]
    bool NothingAt(double x, double y);
    [Gml("object_at", minVersion: GameMakerVersion.v12, maxVersion: GameMakerVersion.v33)]
    bool ObjectAt(double x, double y, int obj);
    [Gml("show_cursor", minVersion: GameMakerVersion.v12, maxVersion: GameMakerVersion.v33)]
    void ShowCursor(bool show);
    [Gml("check_key", minVersion: GameMakerVersion.v14, maxVersion: GameMakerVersion.v33)]
    bool CheckKey(int keycode);
    [Gml("draw_image", minVersion: GameMakerVersion.v14, maxVersion: GameMakerVersion.v33)]
    void DrawImage(double x, double y, int obj);
    [Gml("draw_subimage", minVersion: GameMakerVersion.v14, maxVersion: GameMakerVersion.v33)]
    void DrawSubimage(double x, double y, int obj, int ind);
    [Gml("set_brush_color", minVersion: GameMakerVersion.v14, maxVersion: GameMakerVersion.v33)]
    void SetBrushColor(int col);
    [Gml("set_pen_color", minVersion: GameMakerVersion.v14, maxVersion: GameMakerVersion.v33)]
    void SetPenColor(int col);
    [Gml("set_font_color", minVersion: GameMakerVersion.v14, maxVersion: GameMakerVersion.v33)]
    void SetFontColor(int col);
    [Gml("set_font_size", minVersion: GameMakerVersion.v14, maxVersion: GameMakerVersion.v33)]
    void SetFontSize(int size);
    [Gml("set_font_style", minVersion: GameMakerVersion.v14, maxVersion: GameMakerVersion.v33)]
    void SetFontStyle(int style);
    [Gml("set_font_align", minVersion: GameMakerVersion.v14, maxVersion: GameMakerVersion.v33)]
    void SetFontAlign(int align);
    [Gml("set_font_name", minVersion: GameMakerVersion.v14, maxVersion: GameMakerVersion.v33)]
    void SetFontName(string name);
    [Gml("draw_ellipse", minVersion: GameMakerVersion.v14, maxVersion: GameMakerVersion.v53a)]
    void DrawEllipse(double x1, double y1, double x2, double y2);
    [Gml("draw_rectangle", minVersion: GameMakerVersion.v14, maxVersion: GameMakerVersion.v53a)]
    void DrawRectangle(double x1, double y1, double x2, double y2);
    [Gml("draw_roundrect", minVersion: GameMakerVersion.v14, maxVersion: GameMakerVersion.v53a)]
    void DrawRoundrect(double x1, double y1, double x2, double y2);
    [Gml("draw_triangle", minVersion: GameMakerVersion.v14, maxVersion: GameMakerVersion.v53a)]
    void DrawTriangle(double x1, double y1, double x2, double y2, double x3, double y3);
    [Gml("file_write", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v30)]
    void FileWrite(double x);
    [Gml("file_read", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v30)]
    double FileRead();
    [Gml("highscore_setcolor", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v33)]
    void HighscoreSetcolor(int col1, int col2);
    [Gml("highscore_setfont", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v33)]
    void HighscoreSetfont(string str);
    [Gml("check_mouse_button", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v33)]
    bool CheckMouseButton(int numb);
    [Gml("check_joystick_direction", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v33)]
    bool CheckJoystickDirection();
    [Gml("check_joystick_button", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v33)]
    bool CheckJoystickButton(int numb);
    [Gml("fullscreen", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v33)]
    void Fullscreen(bool full);
    [Gml("draw_button", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v33)]
    void DrawButton(double x1, double y1, double x2, double y2, bool down);
    [Gml("set_brush_style", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v33)]
    void SetBrushStyle(int style);
    [Gml("set_pen_size", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v33)]
    void SetPenSize(int size);
    [Gml("set_font_angle", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v33)]
    void SetFontAngle(int angle);
    [Gml("file_open_read", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v52)]
    void FileOpenRead(string fname);
    [Gml("file_open_write", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v52)]
    void FileOpenWrite(string fname);
    [Gml("file_close", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v52)]
    void FileClose();
    [Gml("sound_frequency", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v53a)]
    void SoundFrequency(int numb, double value);
    [Gml("draw_circle", minVersion: GameMakerVersion.v20, maxVersion: GameMakerVersion.v53a)]
    void DrawCircle(double xc, double yc, double r);
    [Gml("perform_create_event", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v31)]
    void PerformCreateEvent(int obj);
    [Gml("perform_destroy_event", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v31)]
    void PerformDestroyEvent(int obj);
    [Gml("perform_step_event", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v31)]
    void PerformStepEvent(int obj);
    [Gml("perform_collision_event", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v31)]
    void PerformCollisionEvent(int obj);
    [Gml("perform_alarm_event", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v31)]
    void PerformAlarmEvent(int obj, int numb);
    [Gml("perform_mouse_event", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v31)]
    void PerformMouseEvent(int obj, int numb);
    [Gml("perform_keyboard_event", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v31)]
    void PerformKeyboardEvent(int obj, int key);
    [Gml("perform_meeting_event", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v31)]
    void PerformMeetingEvent(int obj, int obj2);
    [Gml("perform_other_event", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v31)]
    void PerformOtherEvent(int obj, int numb);
    [Gml("set_motion", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v33)]
    void SetMotion(int dir, double speed);
    [Gml("add_motion", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v33)]
    void AddMotion(int dir, double speed);
    [Gml("bounce", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v33)]
    void Bounce();
    [Gml("is_aligned", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v33)]
    bool IsAligned();
    [Gml("align", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v33)]
    void Align();
    [Gml("set_collision_mode", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v33)]
    void SetCollisionMode(int val);
    [Gml("execute", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v33)]
    void Execute(string program, string args, bool wait);
    [Gml("shellexecute", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v33)]
    void Shellexecute(string file, string args);
    [Gml("min3", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v52)]
    double Min3(double x, double y, double z);
    [Gml("max3", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v52)]
    double Max3(double x, double y, double z);
    [Gml("show_text", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v61)]
    void ShowText(string fname, bool full, int backcol, double delay);
    [Gml("show_image", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v61)]
    void ShowImage(string fname, bool full, double delay);
    [Gml("show_video", minVersion: GameMakerVersion.v30, maxVersion: GameMakerVersion.v61)]
    void ShowVideo(string fname, bool full, bool loop);
    [Gml("load_game", minVersion: GameMakerVersion.v31, maxVersion: GameMakerVersion.v33)]
    void LoadGame(string str);
    [Gml("save_game", minVersion: GameMakerVersion.v31, maxVersion: GameMakerVersion.v33)]
    void SaveGame(string str);
    [Gml("find_room", minVersion: GameMakerVersion.v31, maxVersion: GameMakerVersion.v33)]
    void FindRoom(string str);
    [Gml("move_towards", minVersion: GameMakerVersion.v31, maxVersion: GameMakerVersion.v33)]
    void MoveTowards(double x, double y);
    [Gml("get_joystick_xpos", minVersion: GameMakerVersion.v31, maxVersion: GameMakerVersion.v33)]
    double GetJoystickXpos();
    [Gml("get_joystick_ypos", minVersion: GameMakerVersion.v31, maxVersion: GameMakerVersion.v33)]
    double GetJoystickYpos();
    [Gml("get_joystick_zpos", minVersion: GameMakerVersion.v31, maxVersion: GameMakerVersion.v33)]
    double GetJoystickZpos();
    [Gml("draw_tiled_image", minVersion: GameMakerVersion.v33, maxVersion: GameMakerVersion.v33)]
    void DrawTiledImage(double x, double y, int obj);
    [Gml("move_contact", minVersion: GameMakerVersion.v33, maxVersion: GameMakerVersion.v33)]
    void MoveContact();
    [Gml("check_key_direct", minVersion: GameMakerVersion.v33, maxVersion: GameMakerVersion.v33)]
    bool CheckKeyDirect(int keycode);
    [Gml("file_write_string", minVersion: GameMakerVersion.v33, maxVersion: GameMakerVersion.v52)]
    void FileWriteString(string str);
    [Gml("file_write_real", minVersion: GameMakerVersion.v33, maxVersion: GameMakerVersion.v52)]
    void FileWriteReal(double x);
    [Gml("file_writeln", minVersion: GameMakerVersion.v33, maxVersion: GameMakerVersion.v52)]
    void FileWriteln();
    [Gml("file_read_string", minVersion: GameMakerVersion.v33, maxVersion: GameMakerVersion.v52)]
    string FileReadString();
    [Gml("file_read_real", minVersion: GameMakerVersion.v33, maxVersion: GameMakerVersion.v52)]
    double FileReadReal();
    [Gml("file_readln", minVersion: GameMakerVersion.v33, maxVersion: GameMakerVersion.v52)]
    string FileReadln();
    [Gml("file_eof", minVersion: GameMakerVersion.v33, maxVersion: GameMakerVersion.v52)]
    bool FileEof();
    [Gml("background_replace", minVersion: GameMakerVersion.v40, maxVersion: GameMakerVersion.v40)]
    void BackgroundReplace(int ind, string fname);
    [Gml("external_call0", minVersion: GameMakerVersion.v40, maxVersion: GameMakerVersion.v43c)]
    void ExternalCall0(int id);
    [Gml("external_call1", minVersion: GameMakerVersion.v40, maxVersion: GameMakerVersion.v43c)]
    void ExternalCall1(int id);
    [Gml("external_call2", minVersion: GameMakerVersion.v40, maxVersion: GameMakerVersion.v43c)]
    void ExternalCall2(int id);
    [Gml("draw_sprite_transparent", minVersion: GameMakerVersion.v40, maxVersion: GameMakerVersion.v50)]
    void DrawSpriteTransparent(int n, int img, double x, double y, double s, int alpha);
    [Gml("draw_background_transparent", minVersion: GameMakerVersion.v40, maxVersion: GameMakerVersion.v50)]
    void DrawBackgroundTransparent(int n, double x, double y, double s, int alpha);
    [Gml("draw_pixel", minVersion: GameMakerVersion.v40, maxVersion: GameMakerVersion.v53a)]
    void DrawPixel(double x, double y);
    [Gml("draw_fill", minVersion: GameMakerVersion.v40, maxVersion: GameMakerVersion.v53a)]
    void DrawFill(double x, double y);
    [Gml("draw_arc", minVersion: GameMakerVersion.v40, maxVersion: GameMakerVersion.v53a)]
    void DrawArc(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4);
    [Gml("draw_chord", minVersion: GameMakerVersion.v40, maxVersion: GameMakerVersion.v53a)]
    void DrawChord(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4);
    [Gml("draw_pie", minVersion: GameMakerVersion.v40, maxVersion: GameMakerVersion.v53a)]
    void DrawPie(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4);
    [Gml("screen_gamma", minVersion: GameMakerVersion.v40, maxVersion: GameMakerVersion.v53a)]
    void ScreenGamma(int r, int g, int b);
    [Gml("object_name", minVersion: GameMakerVersion.v41, maxVersion: GameMakerVersion.v42a)]
    string ObjectName(int ind);
    [Gml("sprite_name", minVersion: GameMakerVersion.v41, maxVersion: GameMakerVersion.v42a)]
    string SpriteName(int ind);
    [Gml("background_name", minVersion: GameMakerVersion.v41, maxVersion: GameMakerVersion.v42a)]
    string BackgroundName(int ind);
    [Gml("sound_name", minVersion: GameMakerVersion.v41, maxVersion: GameMakerVersion.v42a)]
    string SoundName(int ind);
    [Gml("script_name", minVersion: GameMakerVersion.v41, maxVersion: GameMakerVersion.v42a)]
    string ScriptName(int ind);
    [Gml("external_define3", minVersion: GameMakerVersion.v41, maxVersion: GameMakerVersion.v43c)]
    void ExternalDefine3(string dll, string name, int arg1type, int arg2type, int arg3type, int restype);
    [Gml("external_define4", minVersion: GameMakerVersion.v41, maxVersion: GameMakerVersion.v43c)]
    void ExternalDefine4(string dll, string name, int arg1type, int arg2type, int arg3type, int arg4type, int restype);
    [Gml("external_call3", minVersion: GameMakerVersion.v41, maxVersion: GameMakerVersion.v43c)]
    void ExternalCall3(int id, int arg1, int arg2, int arg3);
    [Gml("external_call4", minVersion: GameMakerVersion.v41, maxVersion: GameMakerVersion.v43c)]
    void ExternalCall4(int id, int arg1, int arg2, int arg3, int arg4);
    [Gml("file_open_append", minVersion: GameMakerVersion.v42a, maxVersion: GameMakerVersion.v51)]
    void FileOpenAppend(string fname);
    [Gml("tile_find", minVersion: GameMakerVersion.v42a, maxVersion: GameMakerVersion.v53a)]
    void TileFind(double x, double y, bool foreground);
    [Gml("tile_delete_at", minVersion: GameMakerVersion.v42a, maxVersion: GameMakerVersion.v53a)]
    void TileDeleteAt(double x, double y, bool foreground);
    [Gml("external_define5", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v43c)]
    void ExternalDefine5(string dll, string name, int arg1type, int arg2type, int arg3type, int arg4type, int arg5type, int restype);
    [Gml("external_define6", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v43c)]
    void ExternalDefine6(string dll, string name, int arg1type, int arg2type, int arg3type, int arg4type, int arg5type, int arg6type, int restype);
    [Gml("external_define7", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v43c)]
    void ExternalDefine7(string dll, string name, int arg1type, int arg2type, int arg3type, int arg4type, int arg5type, int arg6type, int arg7type, int restype);
    [Gml("external_define8", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v43c)]
    void ExternalDefine8(string dll, string name, int arg1type, int arg2type, int arg3type, int arg4type, int arg5type, int arg6type, int arg8type, int restype);
    [Gml("external_call5", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v43c)]
    void ExternalCall5(int id, int arg1, int arg2, int arg3, int arg4, int arg5);
    [Gml("external_call6", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v43c)]
    void ExternalCall6(int id, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6);
    [Gml("external_call7", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v43c)]
    void ExternalCall7(int id, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7);
    [Gml("external_call8", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v43c)]
    void ExternalCall8(int id, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8);
    [Gml("path_get_end", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v52)]
    void PathGetEnd(int ind);
    [Gml("sprite_get_videomem", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v53a)]
    void SpriteGetVideomem(int ind);
    [Gml("sprite_get_loadonuse", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v53a)]
    void SpriteGetLoadonuse(int ind);
    [Gml("sound_get_loadonuse", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v53a)]
    void SoundGetLoadonuse(int ind);
    [Gml("background_get_videomem", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v53a)]
    void BackgroundGetVideomem(int ind);
    [Gml("background_get_loadonuse", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v53a)]
    void BackgroundGetLoadonuse(int ind);
    [Gml("script_get_name", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v61)]
    void ScriptGetName(int ind);
    [Gml("script_get_text", minVersion: GameMakerVersion.v43c, maxVersion: GameMakerVersion.v61)]
    void ScriptGetText(int ind);
    [Gml("datafile_exists", minVersion: GameMakerVersion.v50, maxVersion: GameMakerVersion.v53a)]
    void DatafileExists(int ind);
    [Gml("datafile_get_name", minVersion: GameMakerVersion.v50, maxVersion: GameMakerVersion.v53a)]
    void DatafileGetName(int ind);
    [Gml("datafile_get_filename", minVersion: GameMakerVersion.v50, maxVersion: GameMakerVersion.v53a)]
    void DatafileGetFilename(int ind);
    [Gml("datafile_export", minVersion: GameMakerVersion.v50, maxVersion: GameMakerVersion.v53a)]
    void DatafileExport(int ind, string fname);
    [Gml("datafile_discard", minVersion: GameMakerVersion.v50, maxVersion: GameMakerVersion.v53a)]
    void DatafileDiscard(int ind);
    [Gml("path_set_end", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v52)]
    void PathSetEnd(int ind, int val);
    [Gml("set_graphics_mode", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SetGraphicsMode(bool exclusive, int horres, int coldepth, int freq, bool fullscreen, int winscale, int fullscale);
    [Gml("sprite_set_transparent", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteSetTransparent(int ind, int transp);
    [Gml("sprite_set_videomem", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteSetVideomem(int ind, int mode);
    [Gml("sprite_set_loadonuse", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteSetLoadonuse(int ind, int mode);
    [Gml("sprite_mirror", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteMirror(int ind);
    [Gml("sprite_flip", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteFlip(int ind);
    [Gml("sprite_shift", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteShift(int ind, double x, double y);
    [Gml("sprite_rotate180", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteRotate180(int ind);
    [Gml("sprite_rotate90", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteRotate90(int ind, bool clockwise, bool resize);
    [Gml("sprite_rotate", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteRotate(int ind, double angle, int quality);
    [Gml("sprite_resize", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteResize(int ind, double w, double h, int corner);
    [Gml("sprite_stretch", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteStretch(int ind, double w, double h, int quality);
    [Gml("sprite_scale", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteScale(int ind, double xscale, double yscale, int quality, int corner, bool resize);
    [Gml("sprite_black_white", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteBlackWhite(int ind);
    [Gml("sprite_set_hue", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteSetHue(int ind, int amount);
    [Gml("sprite_change_value", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteChangeValue(int ind, int amount);
    [Gml("sprite_change_saturation", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteChangeSaturation(int ind, int amount);
    [Gml("sprite_fade", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteFade(int ind, int col, int amount);
    [Gml("sprite_screendoor", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteScreendoor(int ind, int amount);
    [Gml("sprite_blur", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void SpriteBlur(int ind, int amount);
    [Gml("background_set_transparent", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundSetTransparent(int ind, int transp);
    [Gml("background_set_videomem", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundSetVideomem(int ind, int mode);
    [Gml("background_set_loadonuse", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundSetLoadonuse(int ind, int mode);
    [Gml("background_mirror", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundMirror(int ind);
    [Gml("background_flip", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundFlip(int ind);
    [Gml("background_shift", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundShift(int ind, double x, double y);
    [Gml("background_rotate180", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundRotate180(int ind);
    [Gml("background_rotate90", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundRotate90(int ind, bool clockwise, bool resize);
    [Gml("background_rotate", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundRotate(int ind, double angle, int quality);
    [Gml("background_resize", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundResize(int ind, double w, double h, int corner);
    [Gml("background_stretch", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundStretch(int ind, double w, double h, int quality);
    [Gml("background_scale", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundScale(int ind, double xscale, double yscale, int quality, int corner, bool resize);
    [Gml("background_black_white", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundBlackWhite(int ind);
    [Gml("background_set_hue", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundSetHue(int ind, int amount);
    [Gml("background_change_value", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundChangeValue(int ind, int amount);
    [Gml("background_change_saturation", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundChangeSaturation(int ind, int amount);
    [Gml("background_fade", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundFade(int ind, int col, int amount);
    [Gml("background_screendoor", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundScreendoor(int ind, int amount);
    [Gml("background_blur", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v53a)]
    void BackgroundBlur(int ind, int amount);
    [Gml("part_type_color", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v60)]
    void PartTypeColor(int ind, int color_start, int color_middle, int color_end);
    [Gml("part_system_doastep", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v60)]
    void PartSystemDoastep(int ind);
    [Gml("part_system_draw", minVersion: GameMakerVersion.v51, maxVersion: GameMakerVersion.v60)]
    void PartSystemDraw(int ind, double x, double y);
    [Gml("mouse_set_screen_position", minVersion: GameMakerVersion.v52, maxVersion: GameMakerVersion.v53a)]
    void MouseSetScreenPosition(double x, double y);
}