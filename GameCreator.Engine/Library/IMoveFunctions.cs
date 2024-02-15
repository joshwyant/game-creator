using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;
public interface IMoveFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v1.1
    //
    [Gml("move_random", v11, v33)]
    void MoveRandom(int obj);
    
    //
    // Introduced in v3.0
    //
    [Gml("set_motion", v30, v33)]
    void SetMotion(int dir, double speed);

    [Gml("add_motion", v30, v33)]
    void AddMotion(int dir, double speed);

    [Gml("bounce", v30, v33)]
    void Bounce();

    [Gml("is_aligned", v30, v33)]
    bool IsAligned();

    [Gml("align", v30, v33)]
    void Align();

    //
    // Introduced in v3.1
    //
    [Gml("move_towards", v31, v33)]
    void MoveTowards(double x, double y);
    #endregion

    //
    // Introduced in v3.1
    //
    [Gml("distance_to_point", v31)]
    double DistanceToPoint(double x, double y);

    [Gml("distance_to_object", v31)]
    double DistanceToObject(string obj);
}