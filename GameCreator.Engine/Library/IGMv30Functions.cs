using GameCreator.Api.Engine;

namespace GameCreator.Engine.Library;
using static GameCreator.Api.Engine.GameMakerVersion;

/*

Functions:
debug_message(str)	3.0
highscore_value(place)	3.0
highscore_name(place)	3.0
arcsin(x)	3.0
arccos(x)	3.0
arctan(x)	3.0
mean(x, y)	3.0
string_length(str)	3.0
string_pos(substr, str)	3.0
string_copy(str, index, count)	3.0
string_delete(str, index, count)	3.0
string_insert(substr, str, index)	3.0
string_lower(str)	3.0
string_upper(str)	3.0
string_repeat(str, count)	3.0

Deprecated functions:
perform_create_event(obj)	3.0	3.1
perform_destroy_event(obj)	3.0	3.1
perform_step_event(obj)	3.0	3.1
perform_collision_event(obj)	3.0	3.1
perform_alarm_event(obj, numb)	3.0	3.1
perform_mouse_event(obj, numb)	3.0	3.1
perform_keyboard_event(obj, key)	3.0	3.1
perform_meeting_event(obj, obj2)	3.0	3.1
perform_other_event(obj, numb)	3.0	3.1
set_motion(dir, speed)	3.0	3.3
add_motion(dir, speed)	3.0	3.3
bounce()	3.0	3.3
is_aligned()	3.0	3.3
align()	3.0	3.3
set_collision_mode(val)	3.0	3.3
end_game()	3.0	3.3
execute(program, args, wait)	3.0	3.3
shellexecute(file, args)	3.0	3.3
min3(x, y, z)	3.0	5.2
max3(x, y, z)	3.0	5.2
show_text(fname, full, backcol, delay)	3.0	6.1
show_image(fname, full, delay)	3.0	6.1
show_video(fname, full, loop)	3.0	6.1

*/

public interface IGMv30Functions
{
}
