using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IGfxWindowFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v1.2
    //
    [Gml("show_cursor", v12, v33)]
    void ShowCursor(bool show);

    //
    // Introduced in v2.0
    //
    [Gml("fullscreen", v20, v33)]
    void Fullscreen(bool full);

    //
    // 5.2
    //
    [Gml("mouse_set_screen_position", v52, v53a)]
    void MouseSetScreenPosition(double x, double y);
    #endregion

    //
    // Introduced in v5.0
    //
    [Gml("set_cursor", v50)]
    void SetCursor(int cur);

    //
    // 6.0
    //
    [Gml("window_get_region_height", v60)]
    double WindowGetRegionHeight();

    [Gml("window_get_region_width", v60)]
    double WindowGetRegionWidth();

    [Gml("window_set_region_size", v60)]
    void WindowSetRegionSize(int w, int h, bool adaptwindow);

    [Gml("window_mouse_set", v60)]
    void WindowMouseSet(double x, double y);

    [Gml("window_mouse_get_y", v60)]
    double WindowMouseGetY();

    [Gml("window_mouse_get_x", v60)]
    double WindowMouseGetX();

    [Gml("window_get_height", v60)]
    double WindowGetHeight();

    [Gml("window_get_width", v60)]
    double WindowGetWidth();

    [Gml("window_get_y", v60)]
    double WindowGetY();

    [Gml("window_get_x", v60)]
    double WindowGetX();

    [Gml("window_default", v60)]
    void WindowDefault();

    [Gml("window_center", v60)]
    void WindowCenter();

    [Gml("window_set_rectangle", v60)]
    void WindowSetRectangle(double x, double y, double w, double h);

    [Gml("window_set_size", v60)]
    void WindowSetSize(double w, double h);

    [Gml("window_set_position", v60)]
    void WindowSetPosition(double x, double y);

    [Gml("window_get_region_scale", v60)]
    double WindowGetRegionScale();

    [Gml("window_set_region_scale", v60)]
    void WindowSetRegionScale(double scale, bool adaptwindow);

    [Gml("window_get_color", v60)]
    int WindowGetColor(int color);

    [Gml("window_set_color", v60)]
    void WindowSetColor(int color);

    [Gml("window_get_cursor", v60)]
    int WindowGetCursor();

    [Gml("window_set_cursor", v60)]
    void WindowSetCursor(int curs);

    [Gml("window_get_caption", v60)]
    string WindowGetCaption();

    [Gml("window_set_caption", v60)]
    void WindowSetCaption(string caption);

    [Gml("window_get_sizeable", v60)]
    bool WindowGetSizeable();

    [Gml("window_set_sizeable", v60)]
    void WindowSetSizeable(bool sizeable);

    [Gml("window_get_stayontop", v60)]
    bool WindowGetStayontop();

    [Gml("window_set_stayontop", v60)]
    void WindowSetStayontop(bool stay);

    [Gml("window_get_showicons", v60)]
    bool WindowGetShowicons();

    [Gml("window_set_showicons", v60)]
    void WindowSetShowicons(bool show);

    [Gml("window_get_showborder", v60)]
    bool WindowGetShowborder();

    [Gml("window_set_showborder", v60)]
    void WindowSetShowborder(bool show);

    [Gml("window_get_fullscreen", v60)]
    bool WindowGetFullscreen();

    [Gml("window_set_fullscreen", v60)]
    void WindowSetFullscreen(bool full);

    [Gml("window_get_visible", v60)]
    bool WindowGetVisible();

    [Gml("window_set_visible", v60)]
    void WindowSetVisible(bool visible);
}
