using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ISoundBasicFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v1.1
    //
    [Gml("sound", v11, v14)]
    void Sound(int numb);

    //
    // Introduced in v2.0
    //
    [Gml("sound_frequency", v20, v53a)]
    void SoundFrequency(int numb, double value);
    #endregion

    //
    // Introduced in v2.0
    //

    [Gml("sound_play", v20)]
    void SoundPlay(double numb);

    [Gml("sound_loop", v20)]
    void SoundLoop(double numb);

    [Gml("sound_stop", v20)]
    void SoundStop(double numb);

    [Gml("sound_volume", v20)]
    void SoundVolume(double numb, double value);

    [Gml("sound_pan", v20)]
    void SoundPan(double numb, double value);

}
