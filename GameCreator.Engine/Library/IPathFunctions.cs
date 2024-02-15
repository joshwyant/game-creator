using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;
public interface IPathFunctions
{
    //
    // 5.3a
    //
    [Gml("path_start", v53a)]
    double PathStart(double path, double speed, double endaction, double absolute);

    [Gml("path_end", v53a)]
    double PathEnd();
}