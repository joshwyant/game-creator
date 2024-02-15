using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IResBackgroundFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v4.3c
    //
    [Gml("background_get_videomem", v43c, v53a)]
    void BackgroundGetVideomem(int ind);

    [Gml("background_get_loadonuse", v43c, v53a)]
    void BackgroundGetLoadonuse(int ind);

    [Gml("background_get_transparent", v43c, v70)]
    bool BackgroundGetTransparent(int ind);
    #endregion

    //
    // Introduced in v4.0
    //
    [Gml("background_discard", v40)]
    void BackgroundDiscard(double numb);

    [Gml("background_restore", v40)]
    void BackgroundRestore(double numb);

    //
    // Introduced in v4.3c
    //
    [Gml("background_exists", v43c)]
    bool BackgroundExists(int ind);

    [Gml("background_get_name", v43c)]
    string BackgroundGetName(int ind);

    [Gml("background_get_width", v43c)]
    int BackgroundGetWidth(int ind);

    [Gml("background_get_height", v43c)]
    int BackgroundGetHeight(int ind);
}
