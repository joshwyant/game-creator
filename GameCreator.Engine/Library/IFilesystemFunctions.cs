using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IFilesystemFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v1.1
    //
    [Gml("write", v11, v20)]
    void Write(int ind, double x);

    [Gml("read", v11, v20)]
    double Read(int ind);

    //
    // Introduced in v2.0
    //
    [Gml("file_write", v20, v30)]
    void FileWrite(double x);

    [Gml("file_read", v20, v30)]
    double FileRead();
    
    [Gml("file_open_read", v20, v52)]
    void FileOpenRead(string fname);

    [Gml("file_open_write", v20, v52)]
    void FileOpenWrite(string fname);

    [Gml("file_close", v20, v52)]
    void FileClose();

    //
    // Introduced in v3.3
    //
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

    //
    // Introduced in v4.2a
    //
    // Replaced with file_text_open_append in v5.2
    [Gml("file_open_append", v42a, v51)]
    void FileOpenAppend(string fname);
    #endregion

    //
    // Introduced in v2.0
    //

    [Gml("file_exists", v20)]
    double FileExists(string fname);

    //
    // Introduced in v3.3
    //

    [Gml("file_delete", v33)]
    void FileDelete(string fname);

    [Gml("file_rename", v33)]
    void FileRename(string oldname, string newname);

    [Gml("file_copy", v33)]
    void FileCopy(string oldname, string newname);

    //
    // Introduced in v4.0
    //
    [Gml("directory_exists", v40)]
    double DirectoryExists(string dname);

    [Gml("directory_create", v40)]
    double DirectoryCreate(string dname);

    //
    // Introduced in v4.3c
    //
    [Gml("file_find_first", v43c)]
    void FileFindFirst(string mask, int attr);

    [Gml("file_find_next", v43c)]
    void FileFindNext();

    [Gml("file_find_close", v43c)]
    void FileFindClose();

    [Gml("file_attributes", v43c)]
    void FileAttributes(string fname, int attr);
}
