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

    //
    // Introduced in v4.3c
    //
    [Gml("external_define5", v43c, v43c)]
    void ExternalDefine5(string dll, string name, int arg1type, int arg2type, int arg3type, int arg4type, int arg5type, int restype);

    [Gml("external_define6", v43c, v43c)]
    void ExternalDefine6(string dll, string name, int arg1type, int arg2type, int arg3type, int arg4type, int arg5type, int arg6type, int restype);

    [Gml("external_define7", v43c, v43c)]
    void ExternalDefine7(string dll, string name, int arg1type, int arg2type, int arg3type, int arg4type, int arg5type, int arg6type, int arg7type, int restype);

    [Gml("external_define8", v43c, v43c)]
    void ExternalDefine8(string dll, string name, int arg1type, int arg2type, int arg3type, int arg4type, int arg5type, int arg6type, int arg8type, int restype);

    [Gml("external_call5", v43c, v43c)]
    void ExternalCall5(int id, int arg1, int arg2, int arg3, int arg4, int arg5);

    [Gml("external_call6", v43c, v43c)]
    void ExternalCall6(int id, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6);

    [Gml("external_call7", v43c, v43c)]
    void ExternalCall7(int id, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7);

    [Gml("external_call8", v43c, v43c)]
    void ExternalCall8(int id, int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8);
    #endregion

    // Introduced in v4.1
    [Gml("execute_string", v41)]
    void ExecuteString(string str);

    // Introduced in v4.3c
    [Gml("execute_file", v43c)]
    void ExecuteFile(string fname);
    
    [Gml("window_handle", v43c)]
    void WindowHandle();

    //
    // Introduced in v5.0
    //
    [Gml("external_define", v50)]
    void ExternalDefine(string dll, string name, string calltype, string restype, int argnumb, params double[] args);

    [Gml("external_call", v50)]
    void ExternalCall(int id, params double[] args);
}
