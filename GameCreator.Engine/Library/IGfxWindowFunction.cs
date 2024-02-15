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
}
