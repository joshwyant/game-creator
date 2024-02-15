using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDynamicSpriteFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v4.1
    //
    [Gml("sprite_add", v41, v70)]
    int SpriteAdd(string fname, int imgnumb, bool precise, bool transparent, bool videomem, bool loadonuse, int xorig, int yorig);

    [Gml("sprite_replace", v41, v70)]
    void SpriteReplace(int ind, string fname, int imgnumb, bool precise, bool transparent, bool videomem, bool loadonuse, int xorig, int yorig);

    //
    // Introduced in v5.1
    //

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

    [Gml("sprite_create_from_screen", v51, v70)]
    int SpriteCreateFromScreen(int left, int top, int right, int bottom, bool precise, bool transparent, bool videomem, bool loadonuse, int xorig, int yorig);

    [Gml("sprite_add_from_screen", v51, v70)]
    int SpriteAddFromScreen(int ind, int left, int top, int right, int bottom);

    [Gml("sprite_set_bbox_mode", v51, v70)]
    void SpriteSetBboxMode(int ind, int mode);

    [Gml("sprite_set_bbox", v51, v70)]
    void SpriteSetBbox(int ind, int left, int top, int right, int bottom);

    [Gml("sprite_set_precise", v51, v70)]
    void SpriteSetPrecise(int ind, int mode);

    //
    // 6.1
    //
    [Gml("sprite_add_from_surface", v61, v70)]
    int SpriteAddFromSurface(int ind, int id, double x, double y, double w, double h);

    [Gml("sprite_create_from_surface", v61, v70)]
    int SpriteCreateFromSurface(int id, double x, double y, double w, double h, bool precise, bool transparent, bool smooth, bool preload, double xorig, double yorig);
    #endregion

    //
    // Introduced in v4.1
    //

    [Gml("sprite_delete", v41)]
    void SpriteDelete(int ind);

    //
    // v5.1
    //
    [Gml("sprite_set_offset", v51)]
    void SpriteSetOffset(int ind, double xoff, double yoff);

    [Gml("sprite_duplicate", v51)]
    int SpriteDuplicate(int ind);

    [Gml("sprite_merge", v51)]
    int SpriteMerge(int ind1, int ind2);

    //
    // 6.0
    //
    [Gml("sprite_set_alpha_from_sprite", v60)]
    void SpriteSetAlphaFromSprite(int ind, int spr);
}
