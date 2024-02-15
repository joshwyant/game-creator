using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IPopupHighscoreFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v1.1
    //
    [Gml("show_highscore", v11, v14)]
    void ShowHighscore(int numb);

    //
    // Introduced in v2.0
    //
    [Gml("highscore_setcolor", v20, v33)]
    void HighscoreSetcolor(int col1, int col2);

    [Gml("highscore_setfont", v20, v33)]
    void HighscoreSetfont(string str);
    #endregion

    //
    // Introduced in v2.0
    //
    [Gml("highscore_show", v20)]
    void HighscoreShow(double numb);

    [Gml("highscore_clear", v20)]
    void HighscoreClear();

    [Gml("highscore_add", v20)]
    void HighscoreAdd(string str, double numb);
}
