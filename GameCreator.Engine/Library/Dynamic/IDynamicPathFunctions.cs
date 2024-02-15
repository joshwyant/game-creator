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

    //
    // 5.3a
    //
    [Gml("path_set_precision", v53a)]
    double PathSetPrecision(double ind, double prec);

    [Gml("path_set_closed", v53a)]
    double PathSetClosed(double ind, double closed);

    [Gml("path_duplicate", v53a)]
    double PathDuplicate(double ind);

    [Gml("path_assign", v53a)]
    double PathAssign(double ind, double path);

    [Gml("path_insert_point", v53a)]
    double PathInsertPoint(double ind, double path);

    [Gml("path_change_point", v53a)]
    double PathChangePoint(double ind, double n, double x, double y, double speed);

    [Gml("path_delete_point", v53a)]
    double PathDeletePoint(double ind, double n);

    [Gml("path_reverse", v53a)]
    double PathReverse(double ind);

    [Gml("path_mirror", v53a)]
    double PathMirror(double ind);

    [Gml("path_flip", v53a)]
    double PathFlip(double ind);

    [Gml("path_rotate", v53a)]
    double PathRotate(double ind, double angle);

    [Gml("path_scale", v53a)]
    double PathScale(double ind, double xscale, double yscale);

    [Gml("path_shift", v53a)]
    double PathShift(double ind, double xshift, double yshift);
}
