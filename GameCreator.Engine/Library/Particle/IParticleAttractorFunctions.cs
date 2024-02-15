using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IParticleAttractorFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 5.1
    //
    [Gml("part_attractor_create", v51)]
    int PartAttractorCreate(int ps);

    [Gml("part_attractor_destroy", v51)]
    void PartAttractorDestroy(int ps, int ind);

    [Gml("part_attractor_destroy_all", v51)]
    void PartAttractorDestroyAll(int ps);

    [Gml("part_attractor_exists", v51)]
    bool PartAttractorExists(int ps, int ind);

    [Gml("part_attractor_clear", v51)]
    void PartAttractorClear(int ps, int ind);

    [Gml("part_attractor_position", v51)]
    void PartAttractorPosition(int ps, int ind, double x, double y);

    [Gml("part_attractor_force", v51)]
    void PartAttractorForce(int ps, int ind, double force, double dist, int kind, bool additive);
}
