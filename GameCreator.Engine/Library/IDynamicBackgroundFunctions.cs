using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDynamicBackgroundFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v4.0
    //
    // Different arguments 4.1+
    [Gml("background_replace", v40, v40)]
    void BackgroundReplace(int ind, string fname);

    //
    // Introduced in v4.1
    //
    [Gml("background_add", v41, v70)]
    int BackgroundAdd(string fname, bool transparent, bool videomem, bool loadonuse);

    [Gml("background_replace", v41, v70)]
    void BackgroundReplace(int ind, string fname, bool transparent, bool videomem, bool loadonuse);

    //
    // Introduced in v5.0
    //

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
    void BackgroundScale(int ind, double xscale, double yscale, int quality);

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

    [Gml("background_create_from_screen", v51, v70)]
    int BackgroundCreateFromScreen(int left, int top, int right, int bottom, bool transparent, bool videomem, bool loadonuse);

    //
    // 6.1
    //
    [Gml("background_create_from_surface", v61, v70)]
    int BackgroundCreateFromSurface(int id, double x, double y, double w, double h, bool transparent, bool smooth, bool preload);
    #endregion

    //
    // Introduced in v4.1
    //
    [Gml("background_delete", v41)]
    void BackgroundDelete(int ind);

    //
    // 5.1
    //
    [Gml("background_duplicate", v51)]
    int BackgroundDuplicate(int ind);

    //
    // 6.0
    //
    [Gml("background_create_gradient", v60)]
    void BackgroundCreateGradient(int w, int h, int col1, int col2, int kind, bool preload);

    [Gml("background_create_color", v60)]
    void BackgroundCreateColor(int w, int h, int color, bool preload);

    [Gml("background_assign", v60)]
    void BackgroundAssign(int ind, int back);

    [Gml("background_set_alpha_from_background", v60)]
    void BackgroundSetAlphaFromBackground(int ind, int back);
}
