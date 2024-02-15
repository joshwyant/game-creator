using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDynamicBackgroundFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v4.0
    //
    // Different arguments 4.1+
    [Gml("background_replace", v40, v40)]
    void BackgroundReplace(int ind, string fname);

    //
    // Introduced in v4.1
    //
    [Gml("background_add", v41, v70)]
    int BackgroundAdd(string fname, bool transparent, bool videomem, bool loadonuse);

    [Gml("background_replace", v41, v70)]
    void BackgroundReplace(int ind, string fname, bool transparent, bool videomem, bool loadonuse);
    #endregion

    //
    // Introduced in v4.1
    //
    [Gml("background_delete", v41)]
    void BackgroundDelete(int ind);
}
