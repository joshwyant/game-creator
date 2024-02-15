using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IPopupSplashFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // Introduced in v1.4
    //
    [Gml("show_info", v14)]
    void ShowInfo();
}
