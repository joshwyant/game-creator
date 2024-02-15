using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IGfxViewFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 6.0
    //
    [Gml("window_views_mouse_set", v60)]
    void WindowViewsMouseSet(double x, double y);

    [Gml("window_views_mouse_get_y", v60)]
    double WindowViewsMouseGetY();

    [Gml("window_views_mouse_get_x", v60)]
    double WindowViewsMouseGetX();

    [Gml("window_view_mouse_set", v60)]
    void WindowViewMouseSet(int id, double x, double y);

    [Gml("window_view_mouse_get_y", v60)]
    double WindowViewMouseGetY(int id);

    [Gml("window_view_mouse_get_x", v60)]
    double WindowViewMouseGetX(int id);

}
