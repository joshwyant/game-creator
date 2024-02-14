using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
string_letters(str)	3.3
string_digits(str)	3.3
string_lettersdigits(str)	3.3
file_delete(fname)	3.3
file_rename(oldname, newname)	3.3
file_copy(oldname, newname)	3.3

*/

public interface IGMv33Functions
{
    [Gml("string_letters", v33)]
    string StringLetters(string str);

    [Gml("string_digits", v33)]
    string StringDigits(string str);

    [Gml("string_lettersdigits", v33)]
    string StringLettersDigits(string str);

    [Gml("file_delete", v33)]
    void FileDelete(string fname);

    [Gml("file_rename", v33)]
    void FileRename(string oldname, string newname);

    [Gml("file_copy", v33)]
    void FileCopy(string oldname, string newname);
}