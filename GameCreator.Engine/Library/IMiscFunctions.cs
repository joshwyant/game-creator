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

    //
    // 5.3a
    //
    [Gml("variable_global_array_get", v53a)]
    double VariableGlobalArrayGet(double name, double ind);

    [Gml("variable_global_array2_get", v53a)]
    double VariableGlobalArray2Get(double name, double ind1, double ind2);

    [Gml("variable_local_array_get", v53a)]
    double VariableLocalArrayGet(double name, double ind);

    [Gml("variable_local_array2_get", v53a)]
    double VariableLocalArray2Get(double name, double ind1, double ind2);

    [Gml("variable_global_array_set", v53a)]
    double VariableGlobalArraySet(double name, double ind, double value);

    [Gml("variable_global_array2_set", v53a)]
    double VariableGlobalArray2Set(double name, double ind1, double ind2, double value);

    [Gml("variable_local_array_set", v53a)]
    double VariableLocalArraySet(double name, double ind, double value);

    [Gml("variable_local_array2_set", v53a)]
    double VariableLocalArray2Set(double name, double ind1, double ind2, double value);
}
