using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IResObjectFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // Introduced in v4.3c
    //
    [Gml("object_exists", v43c)]
    bool ObjectExists(int ind);

    [Gml("object_get_name", v43c)]
    string ObjectGetName(int ind);

    [Gml("object_get_sprite", v43c)]
    int ObjectGetSprite(int ind);

    [Gml("object_get_solid", v43c)]
    bool ObjectGetSolid(int ind);

    [Gml("object_get_visible", v43c)]
    bool ObjectGetVisible(int ind);

    [Gml("object_get_depth", v43c)]
    int ObjectGetDepth(int ind);

    [Gml("object_get_persistent", v43c)]
    bool ObjectGetPersistent(int ind);

    [Gml("object_get_mask", v43c)]
    int ObjectGetMask(int ind);

    [Gml("object_get_parent", v43c)]
    int ObjectGetParent(int ind);

    [Gml("object_is_ancestor", v43c)]
    bool ObjectIsAncestor(int ind1, int ind2);

}
