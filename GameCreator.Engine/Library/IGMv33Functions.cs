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

Deprecated functions:
draw_tiled_image(x, y, obj)	3.3	3.3
move_contact()	3.3	3.3
check_key_direct(keycode)	3.3	3.3
file_write_string(str)	3.3	5.2
file_write_real(x)	3.3	5.2
file_writeln()	3.3	5.2
file_read_string()	3.3	5.2
file_read_real()	3.3	5.2
file_readln()	3.3	5.2
file_eof()	3.3	5.2

*/

public interface IGMv33Functions
{
    #region Deprecated functions
    [Gml("draw_tiled_image", v33, v33)]
    void DrawTiledImage(double x, double y, int obj);

    [Gml("move_contact", v33, v33)]
    void MoveContact();

    [Gml("check_key_direct", v33, v33)]
    bool CheckKeyDirect(int keycode);

    [Gml("file_write_string", v33, v52)]
    void FileWriteString(string str);

    [Gml("file_write_real", v33, v52)]
    void FileWriteReal(double x);

    [Gml("file_writeln", v33, v52)]
    void FileWriteln();

    [Gml("file_read_string", v33, v52)]
    string FileReadString();

    [Gml("file_read_real", v33, v52)]
    double FileReadReal();

    [Gml("file_readln", v33, v52)]
    string FileReadln();

    [Gml("file_eof", v33, v52)]
    bool FileEof();
    #endregion
    
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