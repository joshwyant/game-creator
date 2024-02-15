using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ICollisionFunctions
{
    #region Deprecated Functions
    [Gml("is_free", v11, v33)]
    bool IsFree(double x, double y);

    [Gml("is_empty", v11, v33)]
    bool IsEmpty(double x, double y);

    [Gml("is_meeting", v11, v33)]
    bool IsMeeting(double x, double y, int obj);
    #endregion

}
