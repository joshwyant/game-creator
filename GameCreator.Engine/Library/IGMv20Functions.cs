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

Deprecated functions:
file_write(x)	2.0	3.0
file_read()	2.0	3.0
highscore_setcolor(col1, col2)	2.0	3.3
highscore_setfont(str)	2.0	3.3
check_mouse_button(numb)	2.0	3.3
check_joystick_direction()	2.0	3.3
check_joystick_button(numb)	2.0	3.3
fullscreen(full)	2.0	3.3
draw_button(x1, y1, x2, y2, down)	2.0	3.3
set_brush_style(style)	2.0	3.3
set_pen_size(size)	2.0	3.3
set_font_angle(angle)	2.0	3.3
file_open_read(fname)	2.0	5.2
file_open_write(fname)	2.0	5.2
file_close()	2.0	5.2
sound_frequency(numb, value)	2.0	5.3a
draw_circle(xc, yc, r)	2.0	5.3a

*/

public interface IGMv20Functions
{
    #region Deprecated functions
    [Gml("file_write", v20, v30)]
    void FileWrite(double x);

    [Gml("file_read", v20, v30)]
    double FileRead();

    [Gml("highscore_setcolor", v20, v33)]
    void HighscoreSetcolor(int col1, int col2);

    [Gml("highscore_setfont", v20, v33)]
    void HighscoreSetfont(string str);

    [Gml("check_mouse_button", v20, v33)]
    bool CheckMouseButton(int numb);

    [Gml("check_joystick_direction", v20, v33)]
    bool CheckJoystickDirection();

    [Gml("check_joystick_button", v20, v33)]
    bool CheckJoystickButton(int numb);

    [Gml("fullscreen", v20, v33)]
    void Fullscreen(bool full);

    [Gml("draw_button", v20, v33)]
    void DrawButton(double x1, double y1, double x2, double y2, bool down);

    [Gml("set_brush_style", v20, v33)]
    void SetBrushStyle(int style);

    [Gml("set_pen_size", v20, v33)]
    void SetPenSize(int size);

    [Gml("set_font_angle", v20, v33)]
    void SetFontAngle(int angle);

    [Gml("file_open_read", v20, v52)]
    void FileOpenRead(string fname);

    [Gml("file_open_write", v20, v52)]
    void FileOpenWrite(string fname);

    [Gml("file_close", v20, v52)]
    void FileClose();

    [Gml("sound_frequency", v20, v53a)]
    void SoundFrequency(int numb, double value);

    [Gml("draw_circle", v20, v53a)]
    void DrawCircle(double xc, double yc, double r);
    #endregion
    
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