using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IGfxScreenFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v1.1
    //
    [Gml("redraw", v11, v33)]
    void Redraw();
    #endregion

    //
    // Introduced in v4.0
    //
    [Gml("screen_redraw", v40)]
    void ScreenRedraw();

    [Gml("screen_refresh", v40)]
    void ScreenRefresh();

    [Gml("screen_save", v40)]
    void ScreenSave(string fname);

    [Gml("screen_save_part", v40)]
    void ScreenSavePart(string fname, double left, double top, double right, double bottom);
    
    //
    // 6.0
    //
    [Gml("set_synchronization", v60)]
    void SetSynchronization(bool value);

    [Gml("set_automatic_draw", v60)]
    void SetAutomaticDraw(bool value);
}
