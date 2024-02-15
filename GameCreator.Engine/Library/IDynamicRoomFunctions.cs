using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDynamicRoomFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 5.1
    //
    [Gml("room_set_width", v51)]
    void RoomSetWidth(int ind, int w);

    [Gml("room_set_height", v51)]
    void RoomSetHeight(int ind, int h);

    [Gml("room_set_caption", v51)]
    void RoomSetCaption(int ind, string str);

    [Gml("room_set_persistent", v51)]
    void RoomSetPersistent(int ind, bool val);

    [Gml("room_set_code", v51)]
    void RoomSetCode(int ind, string str);

    [Gml("room_set_background_color", v51)]
    void RoomSetBackgroundColor(int ind, int col, bool show);

    [Gml("room_set_background", v51)]
    void RoomSetBackground(int ind, int bind, bool vis, bool fore, bool back, double x, double y, bool htiled, bool vtiled, double hspeed, double vspeed, int alpha);

    [Gml("room_set_view", v51)]
    void RoomSetView(int ind, int vind, bool vis, double left, double top, double width, double height, double x, double y, double hborder, double vborder, double hspeed, double vspeed, int obj);

    [Gml("room_set_view_enabled", v51)]
    void RoomSetViewEnabled(int ind, bool val);

    [Gml("room_add", v51)]
    int RoomAdd();

    [Gml("room_duplicate", v51)]
    int RoomDuplicate(int ind);

    [Gml("room_instance_add", v51)]
    int RoomInstanceAdd(int ind, double x, double y, int obj);

    [Gml("room_tile_add", v51)]
    int RoomTileAdd(int ind, int back, double left, double top, double width, double height, double x, double y, double depth);

    [Gml("room_tile_add_ext", v51)]
    int RoomTileAddExt(int ind, int back, double left, double top, double width, double height, double x, double y, double depth, double xscale, double yscale, int alpha);

    [Gml("room_tile_clear", v51)]
    void RoomTileClear(int ind);
}
