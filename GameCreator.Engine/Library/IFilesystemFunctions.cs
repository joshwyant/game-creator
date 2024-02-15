using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IFilesystemFunctions
{
    #region Deprecated Functions
    [Gml("write", v11, v20)]
    void Write(int ind, double x);

    [Gml("read", v11, v20)]
    double Read(int ind);
    #endregion

}
