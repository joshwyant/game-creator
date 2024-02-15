using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IResTimelineFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // v5.1
    //
    [Gml("timeline_add", v51)]
    int TimelineAdd();

    [Gml("timeline_delete", v51)]
    void TimelineDelete(int ind);

    [Gml("timeline_moment_add", v51)]
    void TimelineMomentAdd(int ind, int step, string codestr);

    [Gml("timeline_moment_clear", v51)]
    void TimelineMomentClear(int ind, int step);
}
