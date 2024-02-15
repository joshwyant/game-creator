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

    //
    // Introduced in v5.1
    //
    [Gml("variable_global_exists", v51)]
    bool VariableGlobalExists(string name);

    [Gml("variable_local_exists", v51)]
    bool VariableLocalExists(string name);

    [Gml("variable_global_get", v51)]
    object VariableGlobalGet(string name);

    [Gml("variable_global_set", v51)]
    void VariableGlobalSet(string name, object value);

    [Gml("variable_local_set", v51)]
    void VariableLocalSet(string name, object value);
}
