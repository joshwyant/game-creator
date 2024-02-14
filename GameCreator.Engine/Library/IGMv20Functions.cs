using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
highscore_show(numb)	2.0
highscore_clear()	2.0
highscore_add(str, numb)	2.0
degtorad(x)	2.0
radtodeg(x)	2.0
sound_play(numb)	2.0
sound_loop(numb)	2.0
sound_stop(numb)	2.0
sound_volume(numb, value)	2.0
sound_pan(numb, value)	2.0
string_width(text)	2.0
string_height(text)	2.0
file_exists(fname)	2.0

*/

public interface IGMv20Functions
{
    [Gml("highscore_show", v20)]
    void HighscoreShow(double numb);

    [Gml("highscore_clear", v20)]
    void HighscoreClear();

    [Gml("highscore_add", v20)]
    void HighscoreAdd(string str, double numb);

    [Gml("degtorad", v20)]
    double DegToRad(double x);

    [Gml("radtodeg", v20)]
    double RadToDeg(double x);

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

    [Gml("string_width", v20)]
    double StringWidth(string text);

    [Gml("string_height", v20)]
    double StringHeight(string text);

    [Gml("file_exists", v20)]
    double FileExists(string fname);
}