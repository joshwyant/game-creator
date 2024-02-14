using GameCreator.Api.Engine;

namespace GameCreator.Engine.Library;
using static GameCreator.Api.Engine.GameMakerVersion;

/*

Functions:
debug_message(str)	3.0
sleep(num)	3.0
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
    #region Deprecated functions
    [Gml("perform_create_event", v30, v31)]
    void PerformCreateEvent(int obj);

    [Gml("perform_destroy_event", v30, v31)]
    void PerformDestroyEvent(int obj);

    [Gml("perform_step_event", v30, v31)]
    void PerformStepEvent(int obj);

    [Gml("perform_collision_event", v30, v31)]
    void PerformCollisionEvent(int obj);

    [Gml("perform_alarm_event", v30, v31)]
    void PerformAlarmEvent(int obj, int numb);

    [Gml("perform_mouse_event", v30, v31)]
    void PerformMouseEvent(int obj, int numb);

    [Gml("perform_keyboard_event", v30, v31)]
    void PerformKeyboardEvent(int obj, int key);

    [Gml("perform_meeting_event", v30, v31)]
    void PerformMeetingEvent(int obj, int obj2);

    [Gml("perform_other_event", v30, v31)]
    void PerformOtherEvent(int obj, int numb);

    [Gml("set_motion", v30, v33)]
    void SetMotion(int dir, double speed);

    [Gml("add_motion", v30, v33)]
    void AddMotion(int dir, double speed);

    [Gml("bounce", v30, v33)]
    void Bounce();

    [Gml("is_aligned", v30, v33)]
    bool IsAligned();

    [Gml("align", v30, v33)]
    void Align();

    [Gml("set_collision_mode", v30, v33)]
    void SetCollisionMode(int val);

    [Gml("execute", v30, v33)]
    void Execute(string program, string args, bool wait);

    [Gml("shellexecute", v30, v33)]
    void Shellexecute(string file, string args);

    [Gml("min3", v30, v52)]
    double Min3(double x, double y, double z);

    [Gml("max3", v30, v52)]
    double Max3(double x, double y, double z);

    [Gml("show_text", v30, v61)]
    void ShowText(string fname, bool full, int backcol, double delay);

    [Gml("show_image", v30, v61)]
    void ShowImage(string fname, bool full, double delay);

    [Gml("show_video", v30, v61)]
    void ShowVideo(string fname, bool full, bool loop);
    #endregion

    [Gml("debug_message", v30)]
    void DebugMessage(string str);

    [Gml("sleep", v30)]
    void Sleep(double num);

    [Gml("highscore_value", v30)]
    double HighscoreValue(double place);

    [Gml("highscore_name", v30)]
    string HighscoreName(double place);

    [Gml("arcsin", v30)]
    double Arcsin(double x);

    [Gml("arccos", v30)]
    double Arccos(double x);

    [Gml("arctan", v30)]
    double Arctan(double x);

    [Gml("mean", v30)]
    double Mean(double x, double y);

    [Gml("string_length", v30)]
    double StringLength(string str);

    [Gml("string_pos", v30)]
    double StringPos(string substr, string str);

    [Gml("string_copy", v30)]
    string StringCopy(string str, double index, double count);

    [Gml("string_delete", v30)]
    string StringDelete(string str, double index, double count);

    [Gml("string_insert", v30)]
    string StringInsert(string substr, string str, double index);

    [Gml("string_lower", v30)]
    string StringLower(string str);

    [Gml("string_upper", v30)]
    string StringUpper(string str);

    [Gml("string_repeat", v30)]
    string StringRepeat(string str, double count);
}
