using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IPopupHighscoreFunctions
{
    #region Deprecated Functions
    [Gml("show_highscore", v11, v14)]
    void ShowHighscore(int numb);
    #endregion

}
