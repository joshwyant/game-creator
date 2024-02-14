using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
background_create_from_surface(id, x, y, w, h, transparent, smooth, preload)	6.1	7.0
sprite_add_from_surface(ind, id, x, y, w, h)	6.1	7.0
sprite_create_from_surface(id, x, y, w, h, precise, transparent, smooth, preload, xorig, yorig)	6.1	7.0
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

