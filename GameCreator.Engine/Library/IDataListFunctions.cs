using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDataListFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 5.2
    //
    [Gml("ds_list_create", v52)]
    int DsListCreate();

    [Gml("ds_list_destroy", v52)]
    void DsListDestroy(int id);

    [Gml("ds_list_clear", v52)]
    void DsListClear(int id);

    [Gml("ds_list_size", v52)]
    int DsListSize(int id);

    [Gml("ds_list_empty", v52)]
    bool DsListEmpty(int id);

    [Gml("ds_list_add", v52)]
    void DsListAdd(int id, double val);

    [Gml("ds_list_insert", v52)]
    void DsListInsert(int id, int pos, double val);

    [Gml("ds_list_replace", v52)]
    void DsListReplace(int id, int pos, double val);

    [Gml("ds_list_delete", v52)]
    void DsListDelete(int id, int pos);

    [Gml("ds_list_find_index", v52)]
    int DsListFindIndex(int id, double val);

    [Gml("ds_list_find_value", v52)]
    double DsListFindValue(int id, int pos);

    [Gml("ds_list_sort", v52)]
    void DsListSort(int id, bool ascend);
}
