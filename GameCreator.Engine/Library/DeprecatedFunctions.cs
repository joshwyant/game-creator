using GameCreator.Api.Engine;

using static GameCreator.Api.Engine.GameMakerVersion;


namespace GameCreator.Engine.Library;


public interface DeprecatedFunctions
{

    [Gml("object_name", v41, v42a)]
    string ObjectName(int ind);

    [Gml("sprite_name", v41, v42a)]
    string SpriteName(int ind);

    [Gml("background_name", v41, v42a)]
    string BackgroundName(int ind);

    [Gml("sound_name", v41, v42a)]
    string SoundName(int ind);

    [Gml("script_name", v41, v42a)]
    string ScriptName(int ind);

    [Gml("external_define3", v41, v43c)]
    void ExternalDefine3(string dll, string name, int arg1type, int arg2type, int arg3type, int restype);

    [Gml("external_define4", v41, v43c)]
    void ExternalDefine4(string dll, string name, int arg1type, int arg2type, int arg3type, int arg4type, int restype);

    [Gml("external_call3", v41, v43c)]
    void ExternalCall3(int id, int arg1, int arg2, int arg3);

    [Gml("external_call4", v41, v43c)]
    void ExternalCall4(int id, int arg1, int arg2, int arg3, int arg4);

    [Gml("file_open_append", v42a, v51)]
    void FileOpenAppend(string fname);

    [Gml("tile_find", v42a, v53a)]
    void TileFind(double x, double y, bool foreground);

    [Gml("tile_delete_at", v42a, v53a)]
    void TileDeleteAt(double x, double y, bool foreground);

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

    [Gml("datafile_exists", v50, v53a)]
    void DatafileExists(int ind);

    [Gml("datafile_get_name", v50, v53a)]
    void DatafileGetName(int ind);

    [Gml("datafile_get_filename", v50, v53a)]
    void DatafileGetFilename(int ind);

    [Gml("datafile_export", v50, v53a)]
    void DatafileExport(int ind, string fname);

    [Gml("datafile_discard", v50, v53a)]
    void DatafileDiscard(int ind);

    [Gml("path_set_end", v51, v52)]
    void PathSetEnd(int ind, int val);

    [Gml("set_graphics_mode", v51, v53a)]
    void SetGraphicsMode(bool exclusive, int horres, int coldepth, int freq, bool fullscreen, int winscale, int fullscale);

    [Gml("sprite_set_transparent", v51, v53a)]
    void SpriteSetTransparent(int ind, int transp);

    [Gml("sprite_set_videomem", v51, v53a)]
    void SpriteSetVideomem(int ind, int mode);

    [Gml("sprite_set_loadonuse", v51, v53a)]
    void SpriteSetLoadonuse(int ind, int mode);

    [Gml("sprite_mirror", v51, v53a)]
    void SpriteMirror(int ind);

    [Gml("sprite_flip", v51, v53a)]
    void SpriteFlip(int ind);

    [Gml("sprite_shift", v51, v53a)]
    void SpriteShift(int ind, double x, double y);

    [Gml("sprite_rotate180", v51, v53a)]
    void SpriteRotate180(int ind);

    [Gml("sprite_rotate90", v51, v53a)]
    void SpriteRotate90(int ind, bool clockwise, bool resize);

    [Gml("sprite_rotate", v51, v53a)]
    void SpriteRotate(int ind, double angle, int quality);

    [Gml("sprite_resize", v51, v53a)]
    void SpriteResize(int ind, double w, double h, int corner);

    [Gml("sprite_stretch", v51, v53a)]
    void SpriteStretch(int ind, double w, double h, int quality);

    [Gml("sprite_scale", v51, v53a)]
    void SpriteScale(int ind, double xscale, double yscale, int quality, int corner, bool resize);

    [Gml("sprite_black_white", v51, v53a)]
    void SpriteBlackWhite(int ind);

    [Gml("sprite_set_hue", v51, v53a)]
    void SpriteSetHue(int ind, int amount);

    [Gml("sprite_change_value", v51, v53a)]
    void SpriteChangeValue(int ind, int amount);

    [Gml("sprite_change_saturation", v51, v53a)]
    void SpriteChangeSaturation(int ind, int amount);

    [Gml("sprite_fade", v51, v53a)]
    void SpriteFade(int ind, int col, int amount);

    [Gml("sprite_screendoor", v51, v53a)]
    void SpriteScreendoor(int ind, int amount);

    [Gml("sprite_blur", v51, v53a)]
    void SpriteBlur(int ind, int amount);

    [Gml("background_set_transparent", v51, v53a)]
    void BackgroundSetTransparent(int ind, int transp);

    [Gml("background_set_videomem", v51, v53a)]
    void BackgroundSetVideomem(int ind, int mode);

    [Gml("background_set_loadonuse", v51, v53a)]
    void BackgroundSetLoadonuse(int ind, int mode);

    [Gml("background_mirror", v51, v53a)]
    void BackgroundMirror(int ind);

    [Gml("background_flip", v51, v53a)]
    void BackgroundFlip(int ind);

    [Gml("background_shift", v51, v53a)]
    void BackgroundShift(int ind, double x, double y);

    [Gml("background_rotate180", v51, v53a)]
    void BackgroundRotate180(int ind);

    [Gml("background_rotate90", v51, v53a)]
    void BackgroundRotate90(int ind, bool clockwise, bool resize);

    [Gml("background_rotate", v51, v53a)]
    void BackgroundRotate(int ind, double angle, int quality);

    [Gml("background_resize", v51, v53a)]
    void BackgroundResize(int ind, double w, double h, int corner);

    [Gml("background_stretch", v51, v53a)]
    void BackgroundStretch(int ind, double w, double h, int quality);

    [Gml("background_scale", v51, v53a)]
    void BackgroundScale(int ind, double xscale, double yscale, int quality, int corner, bool resize);

    [Gml("background_black_white", v51, v53a)]
    void BackgroundBlackWhite(int ind);

    [Gml("background_set_hue", v51, v53a)]
    void BackgroundSetHue(int ind, int amount);

    [Gml("background_change_value", v51, v53a)]
    void BackgroundChangeValue(int ind, int amount);

    [Gml("background_change_saturation", v51, v53a)]
    void BackgroundChangeSaturation(int ind, int amount);

    [Gml("background_fade", v51, v53a)]
    void BackgroundFade(int ind, int col, int amount);

    [Gml("background_screendoor", v51, v53a)]
    void BackgroundScreendoor(int ind, int amount);

    [Gml("background_blur", v51, v53a)]
    void BackgroundBlur(int ind, int amount);

    [Gml("part_type_color", v51, v60)]
    void PartTypeColor(int ind, int color_start, int color_middle, int color_end);

    [Gml("part_system_doastep", v51, v60)]
    void PartSystemDoastep(int ind);

    [Gml("part_system_draw", v51, v60)]
    void PartSystemDraw(int ind, double x, double y);

    [Gml("mouse_set_screen_position", v52, v53a)]
    void MouseSetScreenPosition(double x, double y);

}