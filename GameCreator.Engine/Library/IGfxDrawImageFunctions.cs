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
    #endregion

    [Gml("draw_tiled_image", v33, v33)]
    void DrawTiledImage(double x, double y, int obj);
}
