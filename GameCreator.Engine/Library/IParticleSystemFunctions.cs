using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IParticleSystemFunctions
{
    #region Deprecated Functions
    // Introduced in v5.1
    [Gml("part_system_doastep", v51, v60)]
    void PartSystemDoastep(int ind);
    #endregion

    //
    // 5.1
    //
    [Gml("part_system_create", v51)]
    int PartSystemCreate();

    [Gml("part_system_destroy", v51)]
    void PartSystemDestroy(int ind);

    [Gml("part_system_destroy_all", v51)]
    void PartSystemDestroyAll();

    [Gml("part_system_exists", v51)]
    bool PartSystemExists(int ind);

    [Gml("part_system_clear", v51)]
    void PartSystemClear(int ind);

    [Gml("part_system_sprite_based", v51)]
    void PartSystemSpriteBased(int ind, bool set);

    [Gml("part_system_draw_order", v51)]
    void PartSystemDrawOrder(int ind, bool oldtonew);
    
    [Gml("part_particles_create", v51)]
    void PartParticlesCreate(int ind, double x, double y, int parttype, int number);

    [Gml("part_particles_clear", v51)]
    void PartParticlesClear(int ind);

    [Gml("part_particles_count", v51)]
    int PartParticlesCount(int ind);
}
