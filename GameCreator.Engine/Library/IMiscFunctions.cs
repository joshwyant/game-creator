using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IMiscFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v3.0
    //
    [Gml("debug_message", v30, v30)]
    void DebugMessage(string str);
    #endregion

    //
    // Introduced in v5.0
    //
    [Gml("show_debug_message", v50)]
    void ShowDebugMessage(string str);
}
