using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IGfxWindowFunctions
{
    #region Deprecated Functions
    // Introduced in v1.2
    [Gml("show_cursor", v12, v33)]
    void ShowCursor(bool show);
    #endregion

}
