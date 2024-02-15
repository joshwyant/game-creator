using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDynamicObjectFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 5.1
    //
    [Gml("object_set_sprite", v51)]
    void ObjectSetSprite(int ind, int spr);

    [Gml("object_set_solid", v51)]
    void ObjectSetSolid(int ind, bool solid);

    [Gml("object_set_visible", v51)]
    void ObjectSetVisible(int ind, bool vis);

    [Gml("object_set_depth", v51)]
    void ObjectSetDepth(int ind, int depth);

    [Gml("object_set_persistent", v51)]
    void ObjectSetPersistent(int ind, bool pers);

    [Gml("object_set_mask", v51)]
    void ObjectSetMask(int ind, int spr);

    [Gml("object_set_parent", v51)]
    void ObjectSetParent(int ind, int obj);

    [Gml("object_add", v51)]
    int ObjectAdd();

    [Gml("object_delete", v51)]
    void ObjectDelete(int ind);

    [Gml("object_event_add", v51)]
    void ObjectEventAdd(int ind, int evtype, int evnumb, string codestr);

    [Gml("object_event_clear", v51)]
    void ObjectEventClear(int ind, int evtype, int evnumb);
}
