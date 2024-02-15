using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
screen_wait_vsync()	6.1	
median(val1, val2, …)	6.1	
choose(val1, val2, …)	6.1	
d3d_model_floor(ind, x1, y1, z1, x2, y2, z2, hrepeat, vrepeat)	6.1	
d3d_model_wall(ind, x1, y1, z1, x2, y2, z2, hrepeat, vrepeat)	6.1	
d3d_model_ellipsoid(ind, x1, y1, z1, x2, y2, z2, hrepeat, vrepeat, steps)	6.1	
d3d_model_cone(ind, x1, y1, z1, x2, y2, z2, hrepeat, vrepeat, closed, steps)	6.1	
d3d_model_cylinder(ind, x1, y1, z1, x2, y2, z2, hrepeat, vrepeat, closed, steps)	6.1	
d3d_model_block(ind, x1, y1, z1, x2, y2, z2, hrepeat, vrepeat)	6.1	
d3d_model_primitive_end(ind)	6.1	
d3d_model_vertex_normal_texture_color(ind, x, y, z, nx, ny, nz, xtex, ytex, col, alpha)	6.1	
d3d_model_vertex_normal_texture(ind, x, y, z, nx, ny, nz, xtex, ytex)	6.1	
d3d_model_vertex_normal_color(ind, x, y, z, nx, ny, nz, col, alpha)	6.1	
d3d_model_vertex_normal(ind, x, y, z, nx, ny, nz)	6.1	
d3d_model_vertex_texture_color(ind, x, y, z, xtex, ytex, col, alpha)	6.1	
d3d_model_vertex_texture(ind, x, y, z, xtex, ytex)	6.1	
d3d_model_vertex_color(ind, x, y, z, col, alpha)	6.1	
d3d_model_vertex(ind, x, y, z)	6.1	
d3d_model_primitive_begin(ind, kind)	6.1	
d3d_model_draw(ind, x, y, z, texid)	6.1	
d3d_model_load(ind, fname)	6.1	
d3d_model_save(ind, fname)	6.1	
d3d_model_clear(ind)	6.1	
d3d_model_destroy(ind)	6.1	
d3d_model_create()	6.1	
d3d_set_projection_perspective(x, y, w, h, angle)	6.1	
part_particles_create_color(ind, x, y, parttype, color, number)	6.1	
part_system_drawit(ind)	6.1	
part_system_update(ind)	6.1	
part_system_automatic_draw(ind, automatic)	6.1	
part_system_automatic_update(ind, automatic)	6.1	
part_system_position(ind, x, y)	6.1	
part_system_depth(ind, depth)	6.1	
part_type_blend(ind, additive)	6.1	
part_type_alpha3(ind, alpha1, alpha2, alpha3)	6.1	
part_type_alpha2(ind, alpha1, alpha2)	6.1	
part_type_alpha1(ind, alpha1)	6.1	
part_type_color_hsv(ind, hmin, hmax, smin, smax, vmin, vmax)	6.1	
part_type_color_rgb(ind, rmin, rmax, gmin, gmax, bmin, bmax)	6.1	
part_type_color_mix(ind, color1, color2)	6.1	
part_type_color3(ind, color1, color2, color3)	6.1	
part_type_color1(ind, color1)	6.1	
part_type_orientation(ind, ang_min, ang_max, ang_incr, ang_wiggle, ang_relative)	6.1	
part_type_scale(ind, xscale, yscale)	6.1	
effect_create_above(kind, x, y, size, color)	6.1	
effect_create_below(kind, x, y, size, color)	6.1	
ds_grid_value_disk_y(id, xm, ym, r, val)	6.1	
ds_grid_value_disk_x(id, xm, ym, r, val)	6.1	
ds_grid_value_disk_exists(id, xm, ym, r, val)	6.1	
ds_grid_value_y(id, x1, y1, x2, y2, val)	6.1	
ds_grid_value_x(id, x1, y1, x2, y2, val)	6.1	
ds_grid_value_exists(id, x1, y1, x2, y2, val)	6.1	
ds_grid_get_disk_mean(id, xm, ym, r)	6.1	
ds_grid_get_disk_max(id, xm, ym, r)	6.1	
ds_grid_get_disk_min(id, xm, ym, r)	6.1	
ds_grid_get_disk_sum(id, xm, ym, r)	6.1	
ds_grid_get_mean(id, x1, y1, x2, y2)	6.1	
ds_grid_get_min(id, x1, y1, x2, y2)	6.1	
ds_grid_get_max(id, x1, y1, x2, y2)	6.1	
ds_grid_get_sum(id, x1, y1, x2, y2)	6.1	
ds_grid_get(id, x, y)	6.1	
ds_grid_multiply_disk(id, xm, ym, r, val)	6.1	
ds_grid_add_disk(id, xm, ym, r, val)	6.1	
ds_grid_set_disk(id, xm, ym, r, val)	6.1	
ds_grid_multiply_region(id, x1, y1, x2, y2, val)	6.1	
ds_grid_add_region(id, x1, y1, x2, y2, val)	6.1	
ds_grid_set_region(id, x1, y1, x2, y2, val)	6.1	
ds_grid_multiply(id, x, y, val)	6.1	
ds_grid_add(id, x, y, val)	6.1	
ds_grid_set(id, x, y, val)	6.1	
ds_grid_clear(id, val)	6.1	
ds_grid_height(id)	6.1	
ds_grid_width(id)	6.1	
ds_grid_resize(id, w, h)	6.1	
ds_grid_destroy(id)	6.1	
ds_grid_create(w, h)	6.1	
set_automatic_draw(value)	6.1	
set_synchronization(value)	6.1	
surface_copy_part(destination, x, y, source, xs, ys, ws, hs)	6.1	
surface_copy(destination, x, y, source)	6.1	
draw_surface_general(id, left, top, width, height, x, y, xscale, yscale, rot, c1, c2, c3, c4, alpha)	6.1	
draw_surface_part_ext(id, left, top, width, height, x, y, xscale, yscale, color, alpha)	6.1	
draw_surface_tiled_ext(id, x, y, xscale, yscale, color, alpha)	6.1	
draw_surface_stretched_ext(id, x, y, w, h, color, alpha)	6.1	
draw_surface_ext(id, x, y, xscale, yscale, rot, color, alpha)	6.1	
draw_surface_part(id, left, top, width, height, x, y)	6.1	
draw_surface_tiled(id, x, y)	6.1	
draw_surface_stretched(id, x, y, w, h)	6.1	
surface_save(id, fname)	6.1	
surface_getpixel(id, x, y)	6.1	
surface_reset_target(id)	6.1	
surface_set_target(id)	6.1	
surface_get_texture(id)	6.1	
surface_get_height(id)	6.1	
surface_get_width(id)	6.1	
surface_exists(id)	6.1	
surface_free(id)	6.1	
surface_create(w, h)	6.1	

Deprecated functions:
background_create_from_surface(id, x, y, w, h, transparent, smooth, preload)	6.1	7.0
sprite_add_from_surface(ind, id, x, y, w, h)	6.1	7.0
sprite_create_from_surface(id, x, y, w, h, precise, transparent, smooth, preload, xorig, yorig)	6.1	7.0

*/

public interface IGMv61Functions
{
    #region Deprecated functions
    [Gml("background_create_from_surface", v61, v70)]
    int BackgroundCreateFromSurface(int id, double x, double y, double w, double h, bool transparent, bool smooth, bool preload);

    [Gml("sprite_add_from_surface", v61, v70)]
    int SpriteAddFromSurface(int ind, int id, double x, double y, double w, double h);

    [Gml("sprite_create_from_surface", v61, v70)]
    int SpriteCreateFromSurface(int id, double x, double y, double w, double h, bool precise, bool transparent, bool smooth, bool preload, double xorig, double yorig);
    #endregion

    #region Functions
    [Gml("screen_wait_vsync", v61)]
    void ScreenWaitVsync();

    [Gml("median", v61)]
    double Median(params double[] values);

    [Gml("choose", v61)]
    double Choose(params double[] values);

    [Gml("d3d_model_floor", v61)]
    void D3dModelFloor(int ind, double x1, double y1, double z1, double x2, double y2, double z2, double hrepeat, double vrepeat);

    [Gml("d3d_model_wall", v61)]
    void D3dModelWall(int ind, double x1, double y1, double z1, double x2, double y2, double z2, double hrepeat, double vrepeat);

    [Gml("d3d_model_ellipsoid", v61)]
    void D3dModelEllipsoid(int ind, double x1, double y1, double z1, double x2, double y2, double z2, double hrepeat, double vrepeat, double steps);

    [Gml("d3d_model_cone", v61)]
    void D3dModelCone(int ind, double x1, double y1, double z1, double x2, double y2, double z2, double hrepeat, double vrepeat, bool closed, double steps);

    [Gml("d3d_model_cylinder", v61)]
    void D3dModelCylinder(int ind, double x1, double y1, double z1, double x2, double y2, double z2, double hrepeat, double vrepeat, bool closed, double steps);

    [Gml("d3d_model_block", v61)]
    void D3dModelBlock(int ind, double x1, double y1, double z1, double x2, double y2, double z2, double hrepeat, double vrepeat);

    [Gml("d3d_model_primitive_end", v61)]
    void D3dModelPrimitiveEnd(int ind);

    [Gml("d3d_model_vertex_normal_texture_color", v61)]
    void D3dModelVertexNormalTextureColor(int ind, double x, double y, double z, double nx, double ny, double nz, double xtex, double ytex, double col, double alpha);

    [Gml("d3d_model_vertex_normal_texture", v61)]
    void D3dModelVertexNormalTexture(int ind, double x, double y, double z, double nx, double ny, double nz, double xtex, double ytex);

    [Gml("d3d_model_vertex_normal_color", v61)]
    void D3dModelVertexNormalColor(int ind, double x, double y, double z, double nx, double ny, double nz, double col, double alpha);

    [Gml("d3d_model_vertex_normal", v61)]
    void D3dModelVertexNormal(int ind, double x, double y, double z, double nx, double ny, double nz);

    [Gml("d3d_model_vertex_texture_color", v61)]
    void D3dModelVertexTextureColor(int ind, double x, double y, double z, double xtex, double ytex, double col, double alpha);

    [Gml("d3d_model_vertex_texture", v61)]
    void D3dModelVertexTexture(int ind, double x, double y, double z, double xtex, double ytex);

    [Gml("d3d_model_vertex_color", v61)]
    void D3dModelVertexColor(int ind, double x, double y, double z, double col, double alpha);

    [Gml("d3d_model_vertex", v61)]
    void D3dModelVertex(int ind, double x, double y, double z);

    [Gml("d3d_model_primitive_begin", v61)]
    void D3dModelPrimitiveBegin(int ind, int kind);

    [Gml("d3d_model_draw", v61)]
    void D3dModelDraw(int ind, double x, double y, double z, int texid);

    [Gml("d3d_model_load", v61)]
    void D3dModelLoad(int ind, string fname);

    [Gml("d3d_model_save", v61)]
    void D3dModelSave(int ind, string fname);

    [Gml("d3d_model_clear", v61)]
    void D3dModelClear(int ind);

    [Gml("d3d_model_destroy", v61)]
    void D3dModelDestroy(int ind);

    [Gml("d3d_model_create", v61)]
    void D3dModelCreate();

    [Gml("d3d_set_projection_perspective", v61)]
    void D3dSetProjectionPerspective(double x, double y, double w, double h, double angle);

    [Gml("part_particles_create_color", v61)]
    void PartParticlesCreateColor(int ind, double x, double y, int parttype, int color, double number);

    [Gml("part_system_drawit", v61)]
    void PartSystemDrawit(int ind);

    [Gml("part_system_update", v61)]
    void PartSystemUpdate(int ind);

    [Gml("part_system_automatic_draw", v61)]
    void PartSystemAutomaticDraw(int ind, bool automatic);

    [Gml("part_system_automatic_update", v61)]
    void PartSystemAutomaticUpdate(int ind, bool automatic);

    [Gml("part_system_position", v61)]
    void PartSystemPosition(int ind, double x, double y);

    [Gml("part_system_depth", v61)]
    void PartSystemDepth(int ind, double depth);

    [Gml("part_type_blend", v61)]
    void PartTypeBlend(int ind, bool additive);

    [Gml("part_type_alpha3", v61)]
    void PartTypeAlpha3(int ind, double alpha1, double alpha2, double alpha3);

    [Gml("part_type_alpha2", v61)]
    void PartTypeAlpha2(int ind, double alpha1, double alpha2);

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

    [Gml("effect_create_above", v61)]
    void EffectCreateAbove(int kind, double x, double y, double size, int color);

    [Gml("effect_create_below", v61)]
    void EffectCreateBelow(int kind, double x, double y, double size, int color);

    [Gml("ds_grid_value_disk_y", v61)]
    double DsGridValueDiskY(int id, double xm, double ym, double r, double val);

    [Gml("ds_grid_value_disk_x", v61)]
    double DsGridValueDiskX(int id, double xm, double ym, double r, double val);

    [Gml("ds_grid_value_disk_exists", v61)]
    bool DsGridValueDiskExists(int id, double xm, double ym, double r, double val);

    [Gml("ds_grid_value_y", v61)]
    double DsGridValueY(int id, double x1, double y1, double x2, double y2, double val);

    [Gml("ds_grid_value_x", v61)]
    double DsGridValueX(int id, double x1, double y1, double x2, double y2, double val);

    [Gml("ds_grid_value_exists", v61)]
    bool DsGridValueExists(int id, double x1, double y1, double x2, double y2, double val);

    [Gml("ds_grid_get_disk_mean", v61)]
    double DsGridGetDiskMean(int id, double xm, double ym, double r);

    [Gml("ds_grid_get_disk_max", v61)]
    double DsGridGetDiskMax(int id, double xm, double ym, double r);

    [Gml("ds_grid_get_disk_min", v61)]
    double DsGridGetDiskMin(int id, double xm, double ym, double r);

    [Gml("ds_grid_get_disk_sum", v61)]
    double DsGridGetDiskSum(int id, double xm, double ym, double r);

    [Gml("ds_grid_get_mean", v61)]
    double DsGridGetMean(int id, double x1, double y1, double x2, double y2);

    [Gml("ds_grid_get_min", v61)]
    double DsGridGetMin(int id, double x1, double y1, double x2, double y2);

    [Gml("ds_grid_get_max", v61)]
    double DsGridGetMax(int id, double x1, double y1, double x2, double y2);

    [Gml("ds_grid_get_sum", v61)]
    double DsGridGetSum(int id, double x1, double y1, double x2, double y2);

    [Gml("ds_grid_get", v61)]
    double DsGridGet(int id, double x, double y);

    [Gml("ds_grid_multiply_disk", v61)]
    void DsGridMultiplyDisk(int id, double xm, double ym, double r, double val);

    [Gml("ds_grid_add_disk", v61)]
    void DsGridAddDisk(int id, double xm, double ym, double r, double val);

    [Gml("ds_grid_set_disk", v61)]
    void DsGridSetDisk(int id, double xm, double ym, double r, double val);

    [Gml("ds_grid_multiply_region", v61)]
    void DsGridMultiplyRegion(int id, double x1, double y1, double x2, double y2, double val);

    [Gml("ds_grid_add_region", v61)]
    void DsGridAddRegion(int id, double x1, double y1, double x2, double y2, double val);

    [Gml("ds_grid_set_region", v61)]
    void DsGridSetRegion(int id, double x1, double y1, double x2, double y2, double val);

    [Gml("ds_grid_multiply", v61)]
    void DsGridMultiply(int id, double x, double y, double val);

    [Gml("ds_grid_add", v61)]
    void DsGridAdd(int id, double x, double y, double val);

    [Gml("ds_grid_set", v61)]
    void DsGridSet(int id, double x, double y, double val);

    [Gml("ds_grid_clear", v61)]
    void DsGridClear(int id, double val);

    [Gml("ds_grid_height", v61)]
    double DsGridHeight(int id);

    [Gml("ds_grid_width", v61)]
    double DsGridWidth(int id);

    [Gml("ds_grid_resize", v61)]
    void DsGridResize(int id, double w, double h);

    [Gml("ds_grid_destroy", v61)]
    void DsGridDestroy(int id);

    [Gml("ds_grid_create", v61)]
    void DsGridCreate(double w, double h);

    [Gml("set_automatic_draw", v61)]
    void SetAutomaticDraw(double value);

    [Gml("set_synchronization", v61)]
    void SetSynchronization(double value);

    [Gml("surface_copy_part", v61)]
    void SurfaceCopyPart(int destination, double x, double y, int source, double xs, double ys, double ws, double hs);

    [Gml("surface_copy", v61)]
    void SurfaceCopy(int destination, double x, double y, int source);

    [Gml("draw_surface_general", v61)]
    void DrawSurfaceGeneral(int id, double left, double top, double width, double height, double x, double y, double xscale, double yscale, double rot, double c1, double c2, double c3, double c4, double alpha);

    [Gml("draw_surface_part_ext", v61)]
    void DrawSurfacePartExt(int id, double left, double top, double width, double height, double x, double y, double xscale, double yscale, double color, double alpha);

    [Gml("draw_surface_tiled_ext", v61)]
    void DrawSurfaceTiledExt(int id, double x, double y, double xscale, double yscale, double color, double alpha);

    [Gml("draw_surface_stretched_ext", v61)]
    void DrawSurfaceStretchedExt(int id, double x, double y, double w, double h, double color, double alpha);

    [Gml("draw_surface_ext", v61)]
    void DrawSurfaceExt(int id, double x, double y, double xscale, double yscale, double rot, double color, double alpha);

    [Gml("draw_surface_part", v61)]
    void DrawSurfacePart(int id, double left, double top, double width, double height, double x, double y);

    [Gml("draw_surface_tiled", v61)]
    void DrawSurfaceTiled(int id, double x, double y);

    [Gml("draw_surface_stretched", v61)]
    void DrawSurfaceStretched(int id, double x, double y, double w, double h);

    [Gml("surface_save", v61)]
    void SurfaceSave(int id, string fname);

    [Gml("surface_getpixel", v61)]
    double SurfaceGetpixel(int id, double x, double y);

    [Gml("surface_reset_target", v61)]
    void SurfaceResetTarget(int id);

    [Gml("surface_set_target", v61)]
    void SurfaceSetTarget(int id);

    [Gml("surface_get_texture", v61)]

    double SurfaceGetTexture(int id);

    [Gml("surface_get_height", v61)]
    double SurfaceGetHeight(int id);

    [Gml("surface_get_width", v61)]
    double SurfaceGetWidth(int id);

    [Gml("surface_exists", v61)]
    bool SurfaceExists(int id);

    [Gml("surface_free", v61)]
    void SurfaceFree(int id);

    [Gml("surface_create", v61)]
    void SurfaceCreate(double w, double h);
    #endregion
}
