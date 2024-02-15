using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
mplay_ipaddress()	4.2a	
instance_copy(performevent)	4.2a	
draw_polygon_begin()	4.2a	
draw_polygon_vertex(x, y)	4.2a	
draw_polygon_end()	4.2a	
tile_add(background, left, right, width, height, x, y, depth)	4.2a	
tile_delete(id)	4.2a	
tile_exists(id)	4.2a	
tile_get_x(id)	4.2a	
tile_get_y(id)	4.2a	
tile_get_left(id)	4.2a	
tile_get_top(id)	4.2a	
tile_get_width(id)	4.2a	
tile_get_height(id)	4.2a	
tile_get_depth(id)	4.2a	
tile_get_visible(id)	4.2a	
tile_get_xscale(id)	4.2a	
tile_get_yscale(id)	4.2a	
tile_get_background(id)	4.2a	
tile_get_alpha(id)	4.2a	
tile_set_position(id, x, y)	4.2a	
tile_set_region(id, left, right, width, height)	4.2a	
tile_set_background(id, background)	4.2a	
tile_set_visible(id, visible)	4.2a	
tile_set_depth(id, depth)	4.2a	
tile_set_scale(id, xscale, yscale)	4.2a	
tile_set_alpha(id, alpha)	4.2a	

Deprecated functions:
file_open_append(fname)	4.2a	5.1
tile_find(x, y, foreground)	4.2a	5.3a
tile_delete_at(x, y, foreground)	4.2a	5.3a

*/

public interface IGMv42aFunctions
{
    #region Functions
    [Gml("mplay_ipaddress", v42a)]
    string MplayIpaddress();

    [Gml("instance_copy", v42a)]
    int InstanceCopy(bool performevent);

    [Gml("draw_polygon_begin", v42a)]
    void DrawPolygonBegin();

    [Gml("draw_polygon_vertex", v42a)]
    void DrawPolygonVertex(double x, double y);

    [Gml("draw_polygon_end", v42a)]
    void DrawPolygonEnd();

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

    #endregion

    #region Deprecated Functions
    [Gml("file_open_append", v42a, v51)]

    void FileOpenAppend(string fname);
    
    [Gml("tile_find", v42a, v53a)]
    void TileFind(double x, double y, bool foreground);

    [Gml("tile_delete_at", v42a, v53a)]
    void TileDeleteAt(double x, double y, bool foreground);

    #endregion

}