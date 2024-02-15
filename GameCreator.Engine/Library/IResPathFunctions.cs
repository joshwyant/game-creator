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

    //
    // 5.3a
    //
    [Gml("path_get_closed", v53a)]
    double PathGetClosed(double ind);

    [Gml("path_get_precision", v53a)]
    double PathGetPrecision(double ind);

    [Gml("path_get_number", v53a)]
    double PathGetNumber(double ind);

    [Gml("path_get_point_x", v53a)]
    double PathGetPointX(double ind, double n);

    [Gml("path_get_point_y", v53a)]
    double PathGetPointY(double ind, double n);

    [Gml("path_get_point_speed", v53a)]
    double PathGetPointSpeed(double ind, double n);

    [Gml("path_get_x", v53a)]
    double PathGetX(double ind, double pos);

    [Gml("path_get_y", v53a)]
    double PathGetY(double ind, double pos);

    [Gml("path_get_speed", v53a)]
    double PathGetSpeed(double ind, double pos);
}
