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
}
