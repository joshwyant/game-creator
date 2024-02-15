using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ICollisionFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v1.1
    //
    [Gml("is_free", v11, v33)]
    bool IsFree(double x, double y);

    [Gml("is_empty", v11, v33)]
    bool IsEmpty(double x, double y);

    [Gml("is_meeting", v11, v33)]
    bool IsMeeting(double x, double y, int obj);

    // Introduced in v1.2
    [Gml("nothing_at", v12, v33)]
    bool NothingAt(double x, double y);

    [Gml("object_at", v12, v33)]
    bool ObjectAt(double x, double y, int obj);

    //
    // Introduced in v3.0
    //

    [Gml("set_collision_mode", v30, v33)]
    void SetCollisionMode(int val);
    #endregion

}
