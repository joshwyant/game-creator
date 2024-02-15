using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IParticleDestroyerFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 5.1
    //
    [Gml("part_destroyer_create", v51)]
    int PartDestroyerCreate(int ps);

    [Gml("part_destroyer_destroy", v51)]
    void PartDestroyerDestroy(int ps, int ind);

    [Gml("part_destroyer_destroy_all", v51)]
    void PartDestroyerDestroyAll(int ps);

    [Gml("part_destroyer_exists", v51)]
    bool PartDestroyerExists(int ps, int ind);

    [Gml("part_destroyer_clear", v51)]
    void PartDestroyerClear(int ps, int ind);

    [Gml("part_destroyer_region", v51)]
    void PartDestroyerRegion(int ps, int ind, double xmin, double xmax, double ymin, double ymax, int shape);

}
