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
}