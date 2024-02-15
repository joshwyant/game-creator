using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDataMapFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 5.2
    //[Gml("ds_map_create", v52)]
    int DsMapCreate();

    [Gml("ds_map_destroy", v52)]
    void DsMapDestroy(int id);

    [Gml("ds_map_clear", v52)]
    void DsMapClear(int id);

    [Gml("ds_map_size", v52)]
    int DsMapSize(int id);

    [Gml("ds_map_empty", v52)]
    bool DsMapEmpty(int id);

    [Gml("ds_map_add", v52)]
    void DsMapAdd(int id, string key, double val);

    [Gml("ds_map_replace", v52)]
    void DsMapReplace(int id, string key, double val);

    [Gml("ds_map_delete", v52)]
    void DsMapDelete(int id, string key);

    [Gml("ds_map_exists", v52)]
    bool DsMapExists(int id, string key);

    [Gml("ds_map_find_value", v52)]
    double DsMapFindValue(int id, string key);

    [Gml("ds_map_find_previous", v52)]
    string DsMapFindPrevious(int id, string key);

    [Gml("ds_map_find_next", v52)]
    string DsMapFindNext(int id, string key);

    [Gml("ds_map_find_first", v52)]
    string DsMapFindFirst(int id);

    [Gml("ds_map_find_last", v52)]
    string DsMapFindLast(int id);

    //
    // 7.0
    //

    [Gml("ds_map_read", v70)]
    void DsMapRead(int id, string str);

    [Gml("ds_map_write", v70)]
    void DsMapWrite(int id);

    [Gml("ds_map_copy", v70)]
    void DsMapCopy(int id, int source);
}
