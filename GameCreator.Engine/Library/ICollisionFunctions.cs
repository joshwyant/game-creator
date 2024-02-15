using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ICollisionFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 5.3a
    //
    [Gml("collision_point", v53a)]
    double CollisionPoint(double x, double y, double obj, double prec, double notme);

    [Gml("collision_rectangle", v53a)]
    double CollisionRectangle(double x1, double y1, double x2, double y2, double obj, double prec, double notme);

    [Gml("collision_circle", v53a)]
    double CollisionCircle(double xc, double yc, double radius, double obj, double prec, double notme);

    [Gml("collision_ellipse", v53a)]
    double CollisionEllipse(double x1, double y1, double x2, double y2, double obj, double prec, double notme);

    [Gml("collision_line", v53a)]
    double CollisionLine(double x1, double y1, double x2, double y2, double obj, double prec, double notme);
}
