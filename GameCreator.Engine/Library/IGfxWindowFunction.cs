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
    #endregion

    //
    // Introduced in v5.0
    //
    [Gml("set_cursor", v50)]
    void SetCursor(int cur);

}
