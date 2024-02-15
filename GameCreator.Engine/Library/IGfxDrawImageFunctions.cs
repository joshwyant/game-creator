using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IGfxDrawImageFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v1.4
    //
    [Gml("draw_image", v14, v33)]
    void DrawImage(double x, double y, int obj);

    [Gml("draw_subimage", v14, v33)]
    void DrawSubimage(double x, double y, int obj, int ind);

    //
    // Introduced in v3.3
    //
    [Gml("draw_tiled_image", v33, v33)]
    void DrawTiledImage(double x, double y, int obj);

    //
    // Introduced in v4.0
    //
    [Gml("draw_sprite_transparent", v40, v50)]
    void DrawSpriteTransparent(int n, int img, double x, double y, double s, int alpha);

    [Gml("draw_background_transparent", v40, v50)]
    void DrawBackgroundTransparent(int n, double x, double y, double s, int alpha);
    #endregion

    //
    // Introduced in v4.0
    //
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

    //
    // Introduced in v5.0
    //
    [Gml("draw_sprite_tiled", v50)]
    void DrawSpriteTiled(int n, int img, double x, double y);

    //
    // Introduced in v5.1
    //
    [Gml("draw_sprite_tiled_ext", v51)]
    void DrawSpriteTiledExt(int n, int img, double x, double y, double xscale, double yscale, int alpha);

    [Gml("draw_sprite_part", v51)]
    void DrawSpritePart(int n, int img, int left, int top, int right, int bottom, double x, double y);

    [Gml("draw_sprite_part_ext", v51)]
    void DrawSpritePartExt(int n, int img, int left, int top, int right, int bottom, double x, double y, double xscale, double yscale, int alpha);

    [Gml("draw_sprite_part_alpha", v51)]
    void DrawSpritePartAlpha(int n, int img, int left, int top, int right, int bottom, double x, double y, double xscale, double yscale, int alphaspr, int ind);

    [Gml("draw_sprite_stretched_ext", v51)]
    void DrawSpriteStretchedExt(int n, int img, double x, double y, double w, double h, int alpha);

    [Gml("draw_sprite_alpha", v51)]
    void DrawSpriteAlpha(int n, int img, double x, double y, double xscale, double yscale, int alphaspr, int ind);

    [Gml("draw_background_ext", v51)]
    void DrawBackgroundExt(int n, double x, double y);

    [Gml("draw_background_stretched_ext", v51)]
    void DrawBackgroundStretchedExt(int n, double x, double y, double w, double h, int alpha);

    [Gml("draw_background_tiled_ext", v51)]
    void DrawBackgroundTiledExt(int n, double x, double y, double xscale, double yscale, int alpha);

    [Gml("draw_background_part", v51)]
    void DrawBackgroundPart(int n, int left, int top, int right, int bottom, double x, double y);

    [Gml("draw_background_part_ext", v51)]
    void DrawBackgroundPartExt(int n, int left, int top, int right, int bottom, double x, double y, double xscale, double yscale, int alpha);

    [Gml("draw_background_alpha", v51)]
    void DrawBackgroundAlpha(int n, double x, double y, double xscale, double yscale, int alphaback);

    [Gml("draw_background_part_alpha", v51)]
    void DrawBackgroundPartAlpha(int n, int left, int top, int right, int bottom, double x, double y, double xscale, double yscale, int alphaback);

    //
    // v6.0
    //
    [Gml("draw_sprite_general", v60)]
    void DrawSpriteGeneral(int sprite, int subimg, double left, double top, double right, double bottom, double x, double y, double xscale, double yscale, double rot, int c1, int c2, int c3, int c4, double alpha);

    [Gml("draw_background_general", v60)]
    void DrawBackgroundGeneral(int back, double left, double top, double right, double bottom, double x, double y, double xscale, double yscale, double rot, int c1, int c2, int c3, int c4, double alpha);
}
