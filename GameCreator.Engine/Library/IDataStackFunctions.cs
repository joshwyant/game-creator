using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDataStackFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 5.2
    //
    [Gml("ds_set_precision", v52)]
    void DsSetPrecision(int prec);

    [Gml("ds_stack_create", v52)]
    int DsStackCreate();

    [Gml("ds_stack_destroy", v52)]
    void DsStackDestroy(int id);

    [Gml("ds_stack_clear", v52)]
    void DsStackClear(int id);

    [Gml("ds_stack_size", v52)]
    int DsStackSize(int id);

    [Gml("ds_stack_empty", v52)]
    bool DsStackEmpty(int id);

    [Gml("ds_stack_push", v52)]
    void DsStackPush(int id, double val);

    [Gml("ds_stack_pop", v52)]
    double DsStackPop(int id);

    [Gml("ds_stack_top", v52)]
    double DsStackTop(int id);
}
