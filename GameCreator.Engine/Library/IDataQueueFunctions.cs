using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDataQueueFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 5.2
    //
    [Gml("ds_queue_create", v52)]
    int DsQueueCreate();

    [Gml("ds_queue_destroy", v52)]
    void DsQueueDestroy(int id);

    [Gml("ds_queue_clear", v52)]
    void DsQueueClear(int id);

    [Gml("ds_queue_size", v52)]
    int DsQueueSize(int id);

    [Gml("ds_queue_empty", v52)]
    bool DsQueueEmpty(int id);

    [Gml("ds_queue_enqueue", v52)]
    void DsQueueEnqueue(int id, double val);

    [Gml("ds_queue_dequeue", v52)]
    double DsQueueDequeue(int id);

    [Gml("ds_queue_head", v52)]
    double DsQueueHead(int id);

    [Gml("ds_queue_tail", v52)]
    double DsQueueTail(int id);
}
