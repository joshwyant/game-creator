using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IResBackgroundFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // Introduced in v4.0
    //
    [Gml("background_discard", v40)]
    void BackgroundDiscard(double numb);

    [Gml("background_restore", v40)]
    void BackgroundRestore(double numb);
}
