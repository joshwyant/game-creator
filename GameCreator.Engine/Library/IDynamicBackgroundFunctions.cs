using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDynamicBackgroundFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v1.0
    //
    // Different arguments 4.1+
    [Gml("background_replace", v40, v40)]
    void BackgroundReplace(int ind, string fname);
    #endregion

}
