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

    //
    // 6.0
    //
    [Gml("part_type_alpha2", v60)]
    void PartTypeAlpha2(int ind, double alpha_start, double alpha_end);

    [Gml("part_type_alpha", v60)]
    void PartTypeAlpha(int ind, double alpha_start, double alpha_middle, double alpha_end);

    //
    // 6.1
    //

    [Gml("part_type_blend", v61)]
    void PartTypeBlend(int ind, bool additive);

    [Gml("part_type_alpha3", v61)]
    void PartTypeAlpha3(int ind, double alpha1, double alpha2, double alpha3);

    [Gml("part_type_alpha1", v61)]
    void PartTypeAlpha1(int ind, double alpha1);

    [Gml("part_type_color_hsv", v61)]
    void PartTypeColorHsv(int ind, double hmin, double hmax, double smin, double smax, double vmin, double vmax);

    [Gml("part_type_color_rgb", v61)]
    void PartTypeColorRgb(int ind, double rmin, double rmax, double gmin, double gmax, double bmin, double bmax);

    [Gml("part_type_color_mix", v61)]
    void PartTypeColorMix(int ind, int color1, int color2);

    [Gml("part_type_color3", v61)]
    void PartTypeColor3(int ind, int color1, int color2, int color3);

    [Gml("part_type_color1", v61)]
    void PartTypeColor1(int ind, int color1);

    [Gml("part_type_orientation", v61)]
    void PartTypeOrientation(int ind, double ang_min, double ang_max, double ang_incr, double ang_wiggle, bool ang_relative);

    [Gml("part_type_scale", v61)]
    void PartTypeScale(int ind, double xscale, double yscale);
}
