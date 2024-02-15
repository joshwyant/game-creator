using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;
public interface IMotionPlanningFunctions
{
    //
    // 5.3a
    //
    [Gml("mp_linear_step", v53a)]
    double MpLinearStep(double x, double y, double stepsize, double checkall);

    [Gml("mp_potential_step", v53a)]
    double MpPotentialStep(double x, double y, double stepsize, double checkall);

    [Gml("mp_potential_settings", v53a)]
    double MpPotentialSettings(double maxrot, double rotstep, double ahead, double onspot);

    [Gml("mp_linear_path", v53a)]
    double MpLinearPath(double path, double xg, double yg, double stepsize, double checkall);

    [Gml("mp_potential_path", v53a)]
    double MpPotentialPath(double path, double xg, double yg, double stepsize, double checkall, double factor);

    [Gml("mp_grid_create", v53a)]
    double MpGridCreate(double left, double top, double hcells, double vcells, double cellwidth, double cellheight);

    [Gml("mp_grid_destroy", v53a)]
    double MpGridDestroy(double id);

    [Gml("mp_grid_clear_all", v53a)]
    double MpGridClearAll(double id);

    [Gml("mp_grid_clear_cell", v53a)]
    double MpGridClearCell(double id, double h, double v);

    [Gml("mp_grid_clear_rectangle", v53a)]
    double MpGridClearRectangle(double id, double left, double top, double right, double bottom);

    [Gml("mp_grid_add_cell", v53a)]
    double MpGridAddCell(double id, double h, double v);

    [Gml("mp_grid_add_rectangle", v53a)]
    double MpGridAddRectangle(double id, double left, double top, double right, double bottom);

    [Gml("mp_grid_add_instances", v53a)]
    double MpGridAddInstances(double id, double obj, double prec);

    [Gml("mp_grid_path", v53a)]
    double MpGridPath(double id, double path, double xstart, double ystart, double xgoal, double ygoal, double allowdiag);

    [Gml("mp_grid_draw", v53a)]
    double MpGridDraw(double id);
    
}