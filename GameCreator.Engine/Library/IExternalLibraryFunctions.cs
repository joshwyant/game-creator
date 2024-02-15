using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IExternalLibraryFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v4.0
    //
    [Gml("external_define0", v40, v43c)]
    double ExternalDefine0(string dll, string name, string restype);

    [Gml("external_define1", v40, v43c)]
    double ExternalDefine1(string dll, string name, string arg1type, string restype);

    [Gml("external_define2", v40, v43c)]
    double ExternalDefine2(string dll, string name, string arg1type, string arg2type, string restype);

    [Gml("external_call0", v40, v43c)]
    void ExternalCall0(int id);

    [Gml("external_call1", v40, v43c)]
    void ExternalCall1(int id);

    [Gml("external_call2", v40, v43c)]
    void ExternalCall2(int id);
    #endregion

    // Introduced in v4.1
    [Gml("execute_string", v41)]
    void ExecuteString(string str);

}
