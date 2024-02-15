using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IMiscFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // Introduced in v3.0
    //
    [Gml("debug_message", v30)]
    void DebugMessage(string str);

}
