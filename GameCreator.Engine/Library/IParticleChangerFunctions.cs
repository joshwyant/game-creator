using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IParticleChangerFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 5.1
    //
    [Gml("part_changer_create", v51)]
    int PartChangerCreate(int ps);

    [Gml("part_changer_destroy", v51)]
    void PartChangerDestroy(int ps, int ind);

    [Gml("part_changer_destroy_all", v51)]
    void PartChangerDestroyAll(int ps);

    [Gml("part_changer_exists", v51)]
    bool PartChangerExists(int ps, int ind);

    [Gml("part_changer_clear", v51)]
    void PartChangerClear(int ps, int ind);

    [Gml("part_changer_region", v51)]
    void PartChangerRegion(int ps, int ind, double xmin, double xmax, double ymin, double ymax, int shape);

    [Gml("part_changer_types", v51)]
    void PartChangerTypes(int ps, int parttype1, int parttype2);

    [Gml("part_changer_kind", v51)]
    void PartChangerKind(int ps, int kind);

}
