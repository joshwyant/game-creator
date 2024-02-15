using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDynamicTimelineFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 8.0
    //
    [Gml("timeline_clear", v80)]
    void TimelineClear(int ind);
}
