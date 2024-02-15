using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IResScriptFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v4.3c
    //
    [Gml("script_get_name", v43c, v61)]
    void ScriptGetName(int ind);

    [Gml("script_get_text", v43c, v61)]
    void ScriptGetText(int ind);
    #endregion

    //
    // Introduced in v4.3c
    //
    [Gml("script_exists", v43c)]
    bool ScriptExists(int ind);
}
