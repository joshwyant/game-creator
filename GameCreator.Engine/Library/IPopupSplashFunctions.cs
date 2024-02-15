using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IPopupSplashFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v3.0
    //
    [Gml("show_text", v30, v61)]
    void ShowText(string fname, bool full, int backcol, double delay);

    [Gml("show_image", v30, v61)]
    void ShowImage(string fname, bool full, double delay);

    [Gml("show_video", v30, v61)]
    void ShowVideo(string fname, bool full, bool loop);
    #endregion

    //
    // Introduced in v1.4
    //
    [Gml("show_info", v14)]
    void ShowInfo();

    //
    // Introduced in v5.0
    //
    [Gml("load_info", v50)]
    void LoadInfo(string fname);

    //
    // 7.0
    //
    [Gml("splash_set_stop_mouse", v70)]
    void SplashSetStopMouse(bool stop);

    [Gml("splash_set_stop_key", v70)]
    void SplashSetStopKey(bool stop);

    [Gml("splash_set_interrupt", v70)]
    void SplashSetInterrupt(int interrupt);

    [Gml("splash_set_top", v70)]
    void SplashSetTop(bool top);

    [Gml("splash_set_adapt", v70)]
    void SplashSetAdapt(bool adapt);

    [Gml("splash_set_size", v70)]
    void SplashSetSize(double w, double h);

    [Gml("splash_set_border", v70)]
    void SplashSetBorder(bool border);

    [Gml("splash_set_fullscreen", v70)]
    void SplashSetFullscreen(bool full);

    [Gml("splash_set_caption", v70)]
    void SplashSetCaption(string cap);

    [Gml("splash_set_color", v70)]
    void SplashSetColor(int col);

    [Gml("splash_set_cursor", v70)]
    void SplashSetCursor(bool vis);

    [Gml("splash_set_scale", v70)]
    void SplashSetScale(double scale);

    [Gml("splash_set_main", v70)]
    void SplashSetMain(bool main);

    [Gml("splash_show_image", v70)]
    void SplashShowImage(string fname, double delay);

    [Gml("splash_show_text", v70)]
    void SplashShowText(string fname, double delay);

    [Gml("splash_show_video", v70)]
    void SplashShowVideo(string fname, bool loop);

    //
    // 8.0
    //
    [Gml("splash_set_close_button", v80)]
    void SplashSetCloseButton(bool show);

    [Gml("splash_set_position", v80)]
    void SplashSetPosition(double x, double y);

    [Gml("splash_show_web", v80)]
    void SplashShowWeb(string url, double delay);
}
