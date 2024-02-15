using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
sprite_get_transparent(ind)	4.3	7.0
sprite_get_precise(ind)	4.3	7.0
background_get_transparent(ind)	4.3	7.0
draw_text_ext(x, y, str, sep, w)	4.3	
string_width_ext(str, sep, w)	4.3	
string_height_ext(str, sep, w)	4.3	
string_replace(str, substr, newstr)	4.3	
string_replace_all(str, substr, newstr)	4.3	
string_count(substr, str)	4.3	
execute_file(fname)	4.3	
sound_stop_all()	4.3	
parameter_count()	4.3	
parameter_string(ind)	4.3	
get_directory_alt(capt, root)	4.3	
sprite_exists(ind)	4.3	
sprite_get_name(ind)	4.3	
sprite_get_number(ind)	4.3	
sprite_get_width(ind)	4.3	
sprite_get_height(ind)	4.3	
sprite_get_xoffset(ind)	4.3	
sprite_get_yoffset(ind)	4.3	
sprite_get_bbox_left(ind)	4.3	
sprite_get_bbox_right(ind)	4.3	
sprite_get_bbox_top(ind)	4.3	
sprite_get_bbox_bottom(ind)	4.3	
sound_exists(ind)	4.3	
sound_get_name(ind)	4.3	
sound_get_kind(ind)	4.3	
sound_get_buffers(ind)	4.3	
sound_get_effect(ind)	4.3	
background_exists(ind)	4.3	
background_get_name(ind)	4.3	
background_get_width(ind)	4.3	
background_get_height(ind)	4.3	
path_exists(ind)	4.3	
path_get_name(ind)	4.3	
path_get_length(ind)	4.3	
path_get_kind(ind)	4.3	
script_exists(ind)	4.3	
object_exists(ind)	4.3	
object_get_name(ind)	4.3	
object_get_sprite(ind)	4.3	
object_get_solid(ind)	4.3	
object_get_visible(ind)	4.3	
object_get_depth(ind)	4.3	
object_get_persistent(ind)	4.3	
object_get_mask(ind)	4.3	
object_get_parent(ind)	4.3	
object_is_ancestor(ind1, ind2)	4.3	
room_exists(ind)	4.3	
room_get_name(ind)	4.3	
cd_init()	4.3	
cd_present()	4.3	
cd_number()	4.3	
cd_playing()	4.3	
cd_paused()	4.3	
cd_track()	4.3	
cd_track_length(n)	4.3	
cd_position()	4.3	
cd_set_position(pos)	4.3	
cd_play(first, last)	4.3	
cd_stop()	4.3	
cd_pause()	4.3	
cd_resume	4.3	
cd_set_track_position(pos)	4.3	
cd_open_door()	4.3	
cd_close_door()	4.3	
show_message_ext(str, but1, but2, but3)	4.3	
message_background(back)	4.3	
message_button(spr)	4.3	
message_text_font(name, size, color, style)	4.3	
message_button_font(name, size, color, style)	4.3	
message_input_font(name, size, color, style)	4.3	
message_mouse_color(col)	4.3	
message_input_color(col)	4.3	
message_caption(show, str)	4.3	
message_position(x, y)	4.3	
show_error(str, abort)	4.3	
file_find_first(mask, attr)	4.3	
file_find_next()	4.3	
file_find_close()	4.3	
file_attributes(fname, attr)	4.3	
registry_set_root(root)	4.3	
window_handle()	4.3	

Deprecated functions:
external_define5(dll, name, arg1type, arg2type, arg3type, arg4type, arg5type, restype)	4.3	4.3
external_define6(dll, name, arg1type, arg2type, arg3type, arg4type, arg5type, arg6type, restype)	4.3	4.3
external_define7(dll, name, arg1type, arg2type, arg3type, arg4type, arg5type, arg6type, arg7type, restype)	4.3	4.3
external_define8(dll, name, arg1type, arg2type, arg3type, arg4type, arg5type, arg6type, arg8type, restype)	4.3	4.3
external_call5(id, arg1, arg2, arg3, arg4, arg5)	4.3	4.3
external_call6(id, arg1, arg2, arg3, arg4, arg5, arg6)	4.3	4.3
external_call7(id, arg1, arg2, arg3, arg4, arg5, arg6, arg7)	4.3	4.3
external_call8(id, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)	4.3	4.3
path_get_end(ind)	4.3	5.2
sprite_get_videomem(ind)	4.3	5.3a
sprite_get_loadonuse(ind)	4.3	5.3a
sound_get_loadonuse(ind)	4.3	5.3a
background_get_videomem(ind)	4.3	5.3a
background_get_loadonuse(ind)	4.3	5.3a
script_get_name(ind)	4.3	6.1
script_get_text(ind)	4.3	6.1

*/

public interface IGMv43cFunctions
{
    #region Deprecated functions
    [Gml("external_define5", v43c, v43c)]
    void ExternalDefine5(string dll, string name, int arg1type, int arg2type, int arg3type, int arg4type, int arg5type, int restype);

    [Gml("external_define6", v43c, v43c)]
    void ExternalDefine6(string dll, string name, int arg1type, int arg2type, int arg3type, int arg4type, int arg5type, int arg6type, int restype);

    [Gml("external_define7", v43c, v43c)]
    void ExternalDefine7(string dll, string name, int arg1type, int arg2type, int arg3type, int arg4type, int arg5type, int arg6type, int arg7type, int restype);

    [Gml("external_define8", v43c, v43c)]
    void ExternalDefine8(string dll, string name, int arg1type, int arg2type, int arg3type, int arg4type, int arg5type, int arg6type, int arg8type, int restype);

    [Gml("external_call5", v43c, v43c)]
    void ExternalCall5(int id, int arg1, int arg2, int arg3, int arg4, int arg5);

    [Gml("external_call6", v43c, v43c)]
    void ExternalCall6(int id, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6);

    [Gml("external_call7", v43c, v43c)]
    void ExternalCall7(int id, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7);

    [Gml("external_call8", v43c, v43c)]
    void ExternalCall8(int id, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8);

    [Gml("path_get_end", v43c, v52)]
    void PathGetEnd(int ind);

    [Gml("sprite_get_videomem", v43c, v53a)]
    void SpriteGetVideomem(int ind);
    
    [Gml("sprite_get_loadonuse", v43c, v53a)]
    void SpriteGetLoadonuse(int ind);

    [Gml("sound_get_loadonuse", v43c, v53a)]
    void SoundGetLoadonuse(int ind);

    [Gml("background_get_videomem", v43c, v53a)]
    void BackgroundGetVideomem(int ind);

    [Gml("background_get_loadonuse", v43c, v53a)]
    void BackgroundGetLoadonuse(int ind);

    [Gml("script_get_name", v43c, v61)]
    void ScriptGetName(int ind);

    [Gml("script_get_text", v43c, v61)]
    void ScriptGetText(int ind);
    #endregion

    [Gml("sprite_get_transparent", v43c, v70)]
    bool SpriteGetTransparent(int ind);

    [Gml("sprite_get_precise", v43c, v70)]
    bool SpriteGetPrecise(int ind);

    [Gml("background_get_transparent", v43c, v70)]
    bool BackgroundGetTransparent(int ind);

    [Gml("draw_text_ext", v43c)]
    void DrawTextExt(int x, int y, string str, int sep, int w);

    [Gml("string_width_ext", v43c)]
    int StringWidthExt(string str, int sep, int w);

    [Gml("string_height_ext", v43c)]
    int StringHeightExt(string str, int sep, int w);

    [Gml("string_replace", v43c)]
    string StringReplace(string str, string substr, string newstr);

    [Gml("string_replace_all", v43c)]
    string StringReplaceAll(string str, string substr, string newstr);

    [Gml("string_count", v43c)]
    int StringCount(string substr, string str);

    [Gml("execute_file", v43c)]
    void ExecuteFile(string fname);

    [Gml("sound_stop_all", v43c)]
    void SoundStopAll();

    [Gml("parameter_count", v43c)]
    int ParameterCount();

    [Gml("parameter_string", v43c)]
    string ParameterString(int ind);

    [Gml("get_directory_alt", v43c)]
    string GetDirectoryAlt(string capt, string root);

    [Gml("sprite_exists", v43c)]
    bool SpriteExists(int ind);

    [Gml("sprite_get_name", v43c)]
    string SpriteGetName(int ind);

    [Gml("sprite_get_number", v43c)]
    int SpriteGetNumber(int ind);

    [Gml("sprite_get_width", v43c)]
    int SpriteGetWidth(int ind);

    [Gml("sprite_get_height", v43c)]
    int SpriteGetHeight(int ind);

    [Gml("sprite_get_xoffset", v43c)]
    int SpriteGetXoffset(int ind);

    [Gml("sprite_get_yoffset", v43c)]
    int SpriteGetYoffset(int ind);

    [Gml("sprite_get_bbox_left", v43c)]
    int SpriteGetBboxLeft(int ind);

    [Gml("sprite_get_bbox_right", v43c)]
    int SpriteGetBboxRight(int ind);

    [Gml("sprite_get_bbox_top", v43c)]
    int SpriteGetBboxTop(int ind);

    [Gml("sprite_get_bbox_bottom", v43c)]
    int SpriteGetBboxBottom(int ind);

    [Gml("sound_exists", v43c)]
    bool SoundExists(int ind);

    [Gml("sound_get_name", v43c)]
    string SoundGetName(int ind);

    [Gml("sound_get_kind", v43c)]
    int SoundGetKind(int ind);

    [Gml("sound_get_buffers", v43c)]
    int SoundGetBuffers(int ind);

    [Gml("sound_get_effect", v43c)]
    bool SoundGetEffect(int ind);

    [Gml("background_exists", v43c)]
    bool BackgroundExists(int ind);

    [Gml("background_get_name", v43c)]
    string BackgroundGetName(int ind);

    [Gml("background_get_width", v43c)]
    int BackgroundGetWidth(int ind);

    [Gml("background_get_height", v43c)]
    int BackgroundGetHeight(int ind);

    [Gml("path_exists", v43c)]
    bool PathExists(int ind);

    [Gml("path_get_name", v43c)]
    string PathGetName(int ind);

    [Gml("path_get_length", v43c)]
    int PathGetLength(int ind);

    [Gml("path_get_kind", v43c)]
    int PathGetKind(int ind);

    [Gml("script_exists", v43c)]
    bool ScriptExists(int ind);

    [Gml("object_exists", v43c)]
    bool ObjectExists(int ind);

    [Gml("object_get_name", v43c)]
    string ObjectGetName(int ind);

    [Gml("object_get_sprite", v43c)]
    int ObjectGetSprite(int ind);

    [Gml("object_get_solid", v43c)]
    bool ObjectGetSolid(int ind);

    [Gml("object_get_visible", v43c)]
    bool ObjectGetVisible(int ind);

    [Gml("object_get_depth", v43c)]
    int ObjectGetDepth(int ind);

    [Gml("object_get_persistent", v43c)]
    bool ObjectGetPersistent(int ind);

    [Gml("object_get_mask", v43c)]
    int ObjectGetMask(int ind);

    [Gml("object_get_parent", v43c)]
    int ObjectGetParent(int ind);

    [Gml("object_is_ancestor", v43c)]
    bool ObjectIsAncestor(int ind1, int ind2);

    [Gml("room_exists", v43c)]
    bool RoomExists(int ind);

    [Gml("room_get_name", v43c)]
    string RoomGetName(int ind);

    [Gml("cd_init", v43c)]
    void CdInit();

    [Gml("cd_present", v43c)]
    bool CdPresent();

    [Gml("cd_number", v43c)]
    int CdNumber();

    [Gml("cd_playing", v43c)]
    bool CdPlaying();

    [Gml("cd_paused", v43c)]
    bool CdPaused();

    [Gml("cd_track", v43c)]
    int CdTrack();

    [Gml("cd_track_length", v43c)]
    int CdTrackLength(int n);

    [Gml("cd_position", v43c)]
    int CdPosition();

    [Gml("cd_set_position", v43c)]
    void CdSetPosition(int pos);

    [Gml("cd_play", v43c)]
    void CdPlay(int first, int last);

    [Gml("cd_stop", v43c)]
    void CdStop();

    [Gml("cd_pause", v43c)]
    void CdPause();

    [Gml("cd_resume", v43c)]
    void CdResume();

    [Gml("cd_set_track_position", v43c)]
    void CdSetTrackPosition(int pos);

    [Gml("cd_open_door", v43c)]
    void CdOpenDoor();

    [Gml("cd_close_door", v43c)]
    void CdCloseDoor();

    [Gml("show_message_ext", v43c)]
    void ShowMessageExt(string str, string but1, string but2, string but3);

    [Gml("message_background", v43c)]
    void MessageBackground(string back);

    [Gml("message_button", v43c)]
    void MessageButton(string spr);

    [Gml("message_text_font", v43c)]
    void MessageTextFont(string name, int size, int color, int style);

    [Gml("message_button_font", v43c)]
    void MessageButtonFont(string name, int size, int color, int style);

    [Gml("message_input_font", v43c)]
    void MessageInputFont(string name, int size, int color, int style);

    [Gml("message_mouse_color", v43c)]
    void MessageMouseColor(int col);

    [Gml("message_input_color", v43c)]
    void MessageInputColor(int col);

    [Gml("message_caption", v43c)]
    void MessageCaption(bool show, string str);

    [Gml("message_position", v43c)]
    void MessagePosition(int x, int y);

    [Gml("show_error", v43c)]
    void ShowError(string str, bool abort);

    [Gml("file_find_first", v43c)]
    void FileFindFirst(string mask, int attr);

    [Gml("file_find_next", v43c)]
    void FileFindNext();

    [Gml("file_find_close", v43c)]
    void FileFindClose();

    [Gml("file_attributes", v43c)]
    void FileAttributes(string fname, int attr);

    [Gml("registry_set_root", v43c)]
    void RegistrySetRoot(string root);

    [Gml("window_handle", v43c)]
    void WindowHandle();
}