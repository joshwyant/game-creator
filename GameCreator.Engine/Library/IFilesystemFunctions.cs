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
    #endregion

    //
    // Introduced in v2.0
    //

    [Gml("file_exists", v20)]
    double FileExists(string fname);
}
