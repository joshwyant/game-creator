using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IResSoundFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v4.3c
    //
    [Gml("sound_get_loadonuse", v43c, v53a)]
    void SoundGetLoadonuse(int ind);
    #endregion

    //
    // Introduced in v4.0
    //
    [Gml("sound_discard", v40)]
    void SoundDiscard(double index);

    [Gml("sound_restore", v40)]
    void SoundRestore(double index);

    //
    // Introduced in v4.3c 
    //
    [Gml("sound_exists", v43c)]
    bool SoundExists(int ind);

    [Gml("sound_get_name", v43c)]
    string SoundGetName(int ind);

    [Gml("sound_get_kind", v43c)]
    int SoundGetKind(int ind);

    [Gml("sound_get_buffers", v43c)]
    int SoundGetBuffers(int ind);

    [Gml("sound_get_effect", v43c)]
    bool SoundGetEffect(int ind);
}
