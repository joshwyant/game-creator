using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IStringFunctions
{
    //
    // Introduced in v1.4
    //
    [Gml("chr", v14)]
    string Chr(double val);

    [Gml("ord", v14)]
    double Ord(string val);

    [Gml("string", v14)]
    string String(double x);

    //
    // Introduced in v3.0
    //
    
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

    //
    // Introduced in v3.3
    //
    
    [Gml("string_letters", v33)]
    string StringLetters(string str);

    [Gml("string_digits", v33)]
    string StringDigits(string str);

    [Gml("string_lettersdigits", v33)]
    string StringLettersDigits(string str);
}
