using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IScoreFunctions
{
    #region Deprecated Functions
    [Gml("set_score", v11, v11)]
    void SetScore(double numb);
    #endregion

}
