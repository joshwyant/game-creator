using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IParticleEmitterFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 5.1
    //
    [Gml("part_emitter_create", v51)]
    int PartEmitterCreate(int ps);

    [Gml("part_emitter_destroy", v51)]
    void PartEmitterDestroy(int ps, int ind);

    [Gml("part_emitter_destroy_all", v51)]
    void PartEmitterDestroyAll(int ps);

    [Gml("part_emitter_exists", v51)]
    bool PartEmitterExists(int ps, int ind);

    [Gml("part_emitter_clear", v51)]
    void PartEmitterClear(int ps, int ind);

    [Gml("part_emitter_region", v51)]
    void PartEmitterRegion(int ps, int ind, double xmin, double xmax, double ymin, double ymax, int shape, int distribution);

    [Gml("part_emitter_burst", v51)]
    void PartEmitterBurst(int ps, int ind, int parttype, int number);

    [Gml("part_emitter_stream", v51)]
    void PartEmitterStream(int ps, int ind, int parttype, int number);
}
