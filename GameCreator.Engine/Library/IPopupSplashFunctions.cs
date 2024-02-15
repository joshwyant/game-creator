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
}
