using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDataPriorityQueueFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 5.2
    //
    [Gml("ds_priority_create", v52)]
    int DsPriorityCreate();

    [Gml("ds_priority_destroy", v52)]
    void DsPriorityDestroy(int id);

    [Gml("ds_priority_clear", v52)]
    void DsPriorityClear(int id);

    [Gml("ds_priority_size", v52)]
    int DsPrioritySize(int id);

    [Gml("ds_priority_empty", v52)]
    bool DsPriorityEmpty(int id);

    [Gml("ds_priority_add", v52)]
    void DsPriorityAdd(int id, double val, double prio);

    [Gml("ds_priority_change_priority", v52)]
    void DsPriorityChangePriority(int id, double val, double prio);

    [Gml("ds_priority_find_priority", v52)]
    double DsPriorityFindPriority(int id, double val);

    [Gml("ds_priority_delete_value", v52)]
    void DsPriorityDeleteValue(int id, double val);

    [Gml("ds_priority_delete_min", v52)]
    void DsPriorityDeleteMin(int id);

    [Gml("ds_priority_find_min", v52)]
    double DsPriorityFindMin(int id);

    [Gml("ds_priority_delete_max", v52)]
    void DsPriorityDeleteMax(int id);

    [Gml("ds_priority_find_max", v52)]
    double DsPriorityFindMax(int id);
}
