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

    //
    // Introduced in v3.0
    //
    [Gml("highscore_value", v30)]
    double HighscoreValue(double place);

    [Gml("highscore_name", v30)]
    string HighscoreName(double place);

    //
    // Introduced in v5.0
    //
    [Gml("highscore_show_ext", v50)]
    void HighscoreShowExt(double numb, bool back, bool border, int col1, int col2, string name, double size);

    [Gml("highscore_add_current", v50)]
    void HighscoreAddCurrent();

    [Gml("draw_highscore", v50)]
    void DrawHighscore(double x1, double y1, double x2, double y2);
}
