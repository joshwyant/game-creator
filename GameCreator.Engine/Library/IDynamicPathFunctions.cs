using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDynamicPathFunctions
{
    #region Deprecated Functions
    // Introduced in v5.1
    [Gml("path_set_end", v51, v52)]
    void PathSetEnd(int ind, int val);
    #endregion

    //
    // 5.1
    //
    [Gml("path_set_kind", v51)]
    void PathSetKind(int ind, int val);

    [Gml("path_add", v51)]
    int PathAdd();

    [Gml("path_delete", v51)]
    void PathDelete(int ind);

    [Gml("path_add_point", v51)]
    void PathAddPoint(int ind, double x, double y, double speed);

    [Gml("path_clear_points", v51)]
    void PathClearPoints(int ind);
}
