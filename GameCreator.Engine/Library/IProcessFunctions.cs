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

}
