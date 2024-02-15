using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IGfxTileFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v4.2a
    //
    [Gml("tile_find", v42a, v53a)]
    void TileFind(double x, double y, bool foreground);

    [Gml("tile_delete_at", v42a, v53a)]
    void TileDeleteAt(double x, double y, bool foreground);
    #endregion

    //
    // Introduced in v4.2a
    //
    [Gml("tile_add", v42a)]
    int TileAdd(int background, double left, double right, double width, double height, double x, double y, double depth);

    [Gml("tile_delete", v42a)]
    void TileDelete(int id);

    [Gml("tile_exists", v42a)]
    bool TileExists(int id);

    [Gml("tile_get_x", v42a)]
    double TileGetX(int id);

    [Gml("tile_get_y", v42a)]
    double TileGetY(int id);

    [Gml("tile_get_left", v42a)]
    double TileGetLeft(int id);

    [Gml("tile_get_top", v42a)]
    double TileGetTop(int id);

    [Gml("tile_get_width", v42a)]
    double TileGetWidth(int id);

    [Gml("tile_get_height", v42a)]
    double TileGetHeight(int id);

    [Gml("tile_get_depth", v42a)]
    double TileGetDepth(int id);

    [Gml("tile_get_visible", v42a)]
    bool TileGetVisible(int id);

    [Gml("tile_get_xscale", v42a)]
    double TileGetXscale(int id);

    [Gml("tile_get_yscale", v42a)]
    double TileGetYscale(int id);

    [Gml("tile_get_background", v42a)]
    int TileGetBackground(int id);

    [Gml("tile_get_alpha", v42a)]
    double TileGetAlpha(int id);

    [Gml("tile_set_position", v42a)]
    void TileSetPosition(int id, double x, double y);

    [Gml("tile_set_region", v42a)]
    void TileSetRegion(int id, double left, double right, double width, double height);

    [Gml("tile_set_background", v42a)]
    void TileSetBackground(int id, int background);

    [Gml("tile_set_visible", v42a)]
    void TileSetVisible(int id, bool visible);

    [Gml("tile_set_depth", v42a)]
    void TileSetDepth(int id, double depth);

    [Gml("tile_set_scale", v42a)]
    void TileSetScale(int id, double xscale, double yscale);

    [Gml("tile_set_alpha", v42a)]
    void TileSetAlpha(int id, double alpha);

    //
    // 5.2
    //
    [Gml("tile_layer_hide", v52)]
    void TileLayerHide(double depth);

    [Gml("tile_layer_show", v52)]
    void TileLayerShow(double depth);

    [Gml("tile_layer_delete", v52)]
    void TileLayerDelete(double depth);

    [Gml("tile_layer_shift", v52)]
    void TileLayerShift(double depth, double x, double y);

    [Gml("tile_layer_find", v52)]
    int TileLayerFind(double depth, double x, double y);

    [Gml("tile_layer_delete_at", v52)]
    void TileLayerDeleteAt(double depth, double x, double y);

    [Gml("tile_layer_depth", v52)]
    void TileLayerDepth(double depth, double newdepth);
}
