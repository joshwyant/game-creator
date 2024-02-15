using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IResDatafileFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v5.0
    //
    [Gml("datafile_exists", v50, v53a)]
    bool DatafileExists(int ind);

    [Gml("datafile_get_name", v50, v53a)]
    string DatafileGetName(int ind);

    [Gml("datafile_get_filename", v50, v53a)]
    string DatafileGetFilename(int ind);

    [Gml("datafile_export", v50, v53a)]
    void DatafileExport(int ind, string fname);

    [Gml("datafile_discard", v50, v53a)]
    void DatafileDiscard(int ind);
    #endregion

}
