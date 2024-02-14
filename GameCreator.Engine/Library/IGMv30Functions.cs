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

*/

public interface IGMv30Functions
{
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
