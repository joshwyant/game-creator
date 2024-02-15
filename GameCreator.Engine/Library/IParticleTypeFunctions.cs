using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IParticleTypeFunctions
{
    #region Deprecated Functions
    // Introduced in v5.1
    [Gml("part_type_color", v51, v60)]
    void PartTypeColor(int ind, int color_start, int color_middle, int color_end);
    #endregion

    //
    // 5.1
    //
    [Gml("part_type_create", v51)]
    int PartTypeCreate();

    [Gml("part_type_destroy", v51)]
    void PartTypeDestroy(int ind);

    [Gml("part_type_destroy_all", v51)]
    void PartTypeDestroyAll();

    [Gml("part_type_exists", v51)]
    bool PartTypeExists(int ind);

    [Gml("part_type_clear", v51)]
    void PartTypeClear(int ind);

    [Gml("part_type_shape", v51)]
    void PartTypeShape(int ind, int shape);

    [Gml("part_type_sprite", v51)]
    void PartTypeSprite(int ind, int sprite, bool animat, bool stretch, bool random);

    [Gml("part_type_size", v51)]
    void PartTypeSize(int ind, double size_min, double size_max, double size_incr, double size_rand);

    [Gml("part_type_color2", v51)]
    void PartTypeColor2(int ind, int color_start, int color_end);

    [Gml("part_type_life", v51)]
    void PartTypeLife(int ind, double life_min, double life_max);

    [Gml("part_type_speed", v51)]
    void PartTypeSpeed(int ind, double speed_min, double speed_max, double speed_incr, double speed_rand);

    [Gml("part_type_direction", v51)]
    void PartTypeDirection(int ind, double dir_min, double dir_max, double dir_incr, double dir_rand);

    [Gml("part_type_gravity", v51)]
    void PartTypeGravity(int ind, double grav_amount, double grav_dir);

    [Gml("part_type_step", v51)]
    void PartTypeStep(int ind, int step_number, int step_type);

    [Gml("part_type_death", v51)]
    void PartTypeDeath(int ind, int death_number, int death_type);
}
