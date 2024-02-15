using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IProcessFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v3.0
    //
    [Gml("execute", v30, v33)]
    void Execute(string program, string args, bool wait);

    [Gml("shellexecute", v30, v33)]
    void Shellexecute(string file, string args);
    #endregion

    //
    // Introduced in v4.0
    //

    [Gml("execute_program", v40)]
    double ExecuteProgram(string prog, string arg, double wait);

    [Gml("execute_shell", v40)]
    double ExecuteShell(string prog, string arg);

    //
    // Introduced in v4.3c
    //
    [Gml("parameter_count", v43c)]
    int ParameterCount();

    [Gml("parameter_string", v43c)]
    string ParameterString(int ind);

    //
    // 5.2
    //
    [Gml("environment_get_variable", v52)]
    string EnvironmentGetVariable(string name);
    
    [Gml("set_program_priority", v52)]
    void SetProgramPriority(int priority);
}
