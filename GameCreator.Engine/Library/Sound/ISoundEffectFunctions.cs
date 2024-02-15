using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ISoundEffectFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 6.0
    //
    [Gml("sound_effect_equalizer", v60)]
    void SoundEffectEqualizer(int snd, double center, double bandwidth, double gain);

    [Gml("sound_effect_compressor", v60)]
    void SoundEffectCompressor(int snd, double gain, double attack, double release, double threshold, double ratio, double delay);

    [Gml("sound_effect_reverb", v60)]
    void SoundEffectReverb(int snd, double gain, double mix, double time, double ratio);

    [Gml("sound_effect_gargle", v60)]
    void SoundEffectGargle(int snd, int rate, int wave);

    [Gml("sound_effect_flanger", v60)]
    void SoundEffectFlanger(int snd, double wetdry, double depth, double feedback, double frequency, int wave, double delay, double phase);

    [Gml("sound_effect_echo", v60)]
    void SoundEffectEcho(int snd, double wetdry, double feedback, double leftdelay, double rightdelay, double pandelay);

    [Gml("sound_effect_chorus", v60)]
    void SoundEffectChorus(int snd, double wetdry, double depth, double feedback, double frequency, int wave, double delay, double phase);

    [Gml("sound_effect_set", v60)]
    void SoundEffectSet(int snd, int effect);

}
