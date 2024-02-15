using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDynamicSoundFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // Introduced in v4.1
    //
    [Gml("sound_add", v41)]
    int SoundAdd(string fname, int buffers, bool effects, bool loadonuse);

    [Gml("sound_replace", v41)]
    void SoundReplace(int index, string fname, int buffers, bool effects, bool loadonuse);

    [Gml("sound_delete", v41)]
    void SoundDelete(int index);

    //
    // Introduced in v5.1
    //
    [Gml("sound_add", v51)]
    int SoundAdd(string fname, int buffers, int effects, bool loadonuse);

    [Gml("sound_replace", v51)]
    void SoundReplace(int index, string fname, int buffers, int effects, bool loadonuse);

    //
    // 6.0
    //
    [Gml("sound_get_preload", v60)]
    bool SoundGetPreload(int ind);
}
