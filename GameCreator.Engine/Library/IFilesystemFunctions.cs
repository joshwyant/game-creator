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

    //
    // 5.1
    //
    [Gml("ini_open", v51)]
    void IniOpen(string name);

    [Gml("ini_close", v51)]
    void IniClose();

    [Gml("ini_read_string", v51)]
    string IniReadString(string section, string key, string @default);

    [Gml("ini_read_real", v51)]
    double IniReadReal(string section, string key, double @default);

    [Gml("ini_write_string", v51)]
    void IniWriteString(string section, string key, string value);

    [Gml("ini_write_real", v51)]
    void IniWriteReal(string section, string key, double value);

    [Gml("ini_key_exists", v51)]
    bool IniKeyExists(string section, string key);

    [Gml("ini_section_exists", v51)]
    bool IniSectionExists(string section);

    [Gml("ini_key_delete", v51)]
    void IniKeyDelete(string section, string key);

    [Gml("ini_section_delete", v51)]
    void IniSectionDelete(string section);

    //
    // 5.2
    //
    [Gml("filename_name", v52)]
    string FilenameName(string fname);

    [Gml("filename_path", v52)]
    string FilenamePath(string fname);

    [Gml("filename_dir", v52)]
    string FilenameDir(string fname);

    [Gml("filename_drive", v52)]
    string FilenameDrive(string fname);

    [Gml("filename_ext", v52)]
    string FilenameExt(string fname);

    [Gml("filename_change_ext", v52)]
    string FilenameChangeExt(string fname, string newext);

    [Gml("file_bin_open", v52)]
    int FileBinOpen(string fname, int mod);

    [Gml("file_bin_rewrite", v52)]
    void FileBinRewrite(int fileid);

    [Gml("file_bin_close", v52)]
    void FileBinClose(int fileid);

    [Gml("file_bin_size", v52)]
    int FileBinSize(int fileid);

    [Gml("file_bin_position", v52)]
    int FileBinPosition(int fileid);

    [Gml("file_bin_seek", v52)]
    void FileBinSeek(int fileid, int pos);

    [Gml("file_bin_write_byte", v52)]
    void FileBinWriteByte(int fileid, int val);

    [Gml("file_bin_read_byte", v52)]
    int FileBinReadByte(int fileid);

    //
    // 5.3a
    //
    [Gml("file_text_open_read", v53a)]
    double FileTextOpenRead(double fname);

    [Gml("file_text_open_write", v53a)]
    double FileTextOpenWrite(double fname);

    [Gml("file_text_open_append", v53a)]
    double FileTextOpenAppend(double fname);

    [Gml("file_text_close", v53a)]
    double FileTextClose(double fileid);

    [Gml("file_text_write_string", v53a)]
    double FileTextWriteString(double fileid, double str);

    [Gml("file_text_write_real", v53a)]
    double FileTextWriteReal(double fileid, double x);

    [Gml("file_text_writeln", v53a)]
    double FileTextWriteln(double fileid);

    [Gml("file_text_read_string", v53a)]
    double FileTextReadString(double fileid);

    [Gml("file_text_read_real", v53a)]
    double FileTextReadReal(double fileid);

    [Gml("file_text_readln", v53a)]
    double FileTextReadln(double fileid);

    [Gml("file_text_eof", v53a)]
    double FileTextEof(double fileid);
}
