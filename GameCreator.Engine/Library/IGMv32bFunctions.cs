using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
point_distance(x1, y1, x2, y2)	3.2b
point_direction(x1, y1, x2, y2)	3.2b

*/

public interface IGMv32bFunctions
{
    [Gml("point_distance", v32b)]
    double PointDistance(double x1, double y1, double x2, double y2);

    [Gml("point_direction", v32b)]
    double PointDirection(double x1, double y1, double x2, double y2);
}