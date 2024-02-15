using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IParticleDeflectorFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 5.1
    //
    [Gml("part_deflector_create", v51)]
    int PartDeflectorCreate(int ps);

    [Gml("part_deflector_destroy", v51)]
    void PartDeflectorDestroy(int ps, int ind);

    [Gml("part_deflector_destroy_all", v51)]
    void PartDeflectorDestroyAll(int ps);

    [Gml("part_deflector_exists", v51)]
    bool PartDeflectorExists(int ps, int ind);

    [Gml("part_deflector_clear", v51)]
    void PartDeflectorClear(int ps, int ind);

    [Gml("part_deflector_region", v51)]
    void PartDeflectorRegion(int ps, int ind, double xmin, double xmax, double ymin, double ymax);

    [Gml("part_deflector_kind", v51)]
    void PartDeflectorKind(int ps, int kind);

    [Gml("part_deflector_friction", v51)]
    void PartDeflectorFriction(int ps, int kind);
}
