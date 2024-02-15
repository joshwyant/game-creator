using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IResPathFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v4.3c
    //
    [Gml("path_get_end", v43c, v52)]
    void PathGetEnd(int ind);
    #endregion

    //
    // Introduced in v4.3c
    //
    [Gml("path_exists", v43c)]
    bool PathExists(int ind);

    [Gml("path_get_name", v43c)]
    string PathGetName(int ind);

    [Gml("path_get_length", v43c)]
    int PathGetLength(int ind);

    [Gml("path_get_kind", v43c)]
    int PathGetKind(int ind);
}
