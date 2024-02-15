using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IGfxDisplayFunctions
{
    #region Deprecated Functions
    [Gml("set_graphics_mode", v51, v53a)]
    void SetGraphicsMode(bool exclusive, int horres, int coldepth, int freq, bool fullscreen, int winscale, int fullscale);
    #endregion

    //
    // 6.0
    //
    [Gml("display_get_width", v60)]
    int DisplayGetWidth();

    [Gml("display_get_height", v60)]
    int DisplayGetHeight();

    [Gml("display_get_colordepth", v60)]
    int DisplayGetColordepth();

    [Gml("display_mouse_set", v60)]
    void DisplayMouseSet(double x, double y);

    [Gml("display_mouse_get_y", v60)]
    double DisplayMouseGetY();

    [Gml("display_mouse_get_x", v60)]
    double DisplayMouseGetX();

    [Gml("display_reset", v60)]
    void DisplayReset();

    [Gml("display_test_all", v60)]
    bool DisplayTestAll(int w, int h, int frequency, int coldepth);

    [Gml("display_set_all", v60)]
    void DisplaySetAll(int w, int h, int frequency, int coldepth);

    [Gml("display_set_colordepth", v60)]
    void DisplaySetColordepth(int coldepth);

    [Gml("display_set_frequency", v60)]
    void DisplaySetFrequency(int frequency);

    [Gml("display_get_frequency", v60)]
    int DisplayGetFrequency();

    [Gml("display_set_size", v60)]
    void DisplaySetSize(int w, int h);
}
