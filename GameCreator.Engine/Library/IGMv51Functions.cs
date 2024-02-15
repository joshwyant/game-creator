using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
push_graphics_settings()	5.1	
pop_graphics_settings()	5.1	
external_free(dll)	5.1	
lengthdir_x(len, dir)	5.1	
lengthdir_y(len, dir)	5.1	
variable_global_exists(name)	5.1	
variable_local_exists(name)	5.1	
variable_global_get(name)	5.1	
variable_global_set(name, value)	5.1	
variable_local_set(name, value)	5.1	
mouse_wait()	5.1	
draw_sprite_tiled_ext(n, img, x, y, xscale, yscale, alpha)	5.1	
draw_sprite_part(n, img, left, top, right, bottom, x, y)	5.1	
draw_sprite_part_ext(n, img, left, top, right, bottom, x, y, xscale, yscale, alpha)	5.1	
draw_sprite_part_alpha(n, img, left, top, right, bottom, x, y, xscale, yscale, alphaspr?, ind?)	5.1	
draw_sprite_stretched_ext(n, img, x, y, w, h, alpha)	5.1	
draw_sprite_part(n, img, left, top, right, bottom, x, y)	5.1	
draw_sprite_alpha(n, img, x, y, xscale, yscale, alphaspr, ind)	5.1	
draw_background_ext(n, x, y)	5.1	
draw_background_stretched_ext(n, x, y, w, h, alpha)	5.1	
draw_background_tiled_ext(n, x, y, xscale, yscale, alpha)	5.1	
draw_background_part(n, left, top, right, bottom, x, y)	5.1	
draw_background_part_ext(n, left, top, right, bottom, x, y, xscale, yscale, alpha)	5.1	
draw_background_alpha(n, x, y, xscale, yscale, alphaback)	5.1	
draw_background_part_alpha(n, left, top, right, bottom, x, y, xscale, yscale, alphaback?)	5.1	
draw_arrow(x1, y1, x2, y2, size)	5.1	
message_alpha(alpha)	5.1	
sprite_get_bbox_mode(ind)	5.1	
sprite_set_offset(ind, xoff, yoff)	5.1	
sprite_duplicate(ind)	5.1	
sprite_merge(ind1, ind2)	5.1	
sound_add(fname, buffers, effects, loadonuse)	5.1	
sound_replace(index, fname, buffers, effects, loadonuse)	5.1	
background_duplicate(ind)	5.1	
path_set_kind(ind, val)	5.1	
path_add()	5.1	
path_delete(ind)	5.1	
path_add_point(ind, x, y, speed)	5.1	
path_clear_points(ind)	5.1	
script_execute(scr, arg0, arg1, …)	5.1	
timeline_add()	5.1	
timeline_delete(ind)	5.1	
timeline_moment_add(ind, step, codestr)	5.1	
timeline_moment_clear(ind, step)	5.1	
object_set_sprite(ind, spr)	5.1	
object_set_solid(ind, solid)	5.1	
object_set_visible(ind, vis)	5.1	
object_set_depth(ind, depth)	5.1	
object_set_persistent(ind, pers)	5.1	
object_set_mask(ind, spr)	5.1	
object_set_parent(ind, obj)	5.1	
object_add()	5.1	
object_delete(ind)	5.1	
object_event_add(ind, evtype, evnumb, codestr)	5.1	
object_event_clear(ind, evtype, evnumb)	5.1	
room_set_width(ind, w)	5.1	
room_set_height(ind, h)	5.1	
room_set_caption(ind, str)	5.1	
room_set_persistent(ind, val)	5.1	
room_set_code(ind, str)	5.1	
room_set_background_color(ind, col, show)	5.1	
room_set_background(ind, bind, vis, fore, back, x, y, htiled, vtiled, hspeed, vspeed, alpha)	5.1	
room_set_view(ind, vind, vis, left, top, width, height, x, y, hborder, vborder, hspeed, vspeed, obj)	5.1	
room_set_view_enabled(ind, val)	5.1	
room_add()	5.1	
room_duplicate(ind)	5.1	
room_instance_add(ind, x, y, obj)	5.1	
room_tile_add(ind, back, left, top, width, height, x, y, depth)	5.1	
room_tile_add_ext(ind, back, left, top, width, height, x, y, depth, xscale, yscale, alpha)	5.1	
room_tile_clear(ind)	5.1	
ini_open(name)	5.1	
ini_close()	5.1	
ini_read_string(section, key, default)	5.1	
ini_read_real(section, key, default)	5.1	
ini_write_string(section, key, value)	5.1	
ini_write_real(section, key, value)	5.1	
ini_key_exists(section, key)	5.1	
ini_section_exists(section)	5.1	
ini_key_delete(section, key)	5.1	
ini_section_delete(section)	5.1	
part_type_create()	5.1	
part_type_destroy(ind)	5.1	
part_type_destroy_all()	5.1	
part_type_exists(ind)	5.1	
part_type_clear(ind)	5.1	
part_type_shape(ind, shape)	5.1	
part_type_sprite(ind, sprite, animat, stretch, random)	5.1	
part_type_size(ind, size_min, size_max, size_incr, size_rand)	5.1	
part_type_color2(ind, color_start, color_end)	5.1	
part_type_life(ind, life_min, life_max)	5.1	
part_type_speed(ind, speed_min, speed_max, speed_incr, speed_rand)	5.1	
part_type_direction(ind, dir_min, dir_max, dir_incr, dir_rand)	5.1	
part_type_gravity(ind, grav_amount, grav_dir)	5.1	
part_type_step(ind, step_number, step_type)	5.1	
part_type_death(ind, death_number, death_type)	5.1	
part_system_create()	5.1	
part_system_destroy(ind)	5.1	
part_system_destroy_all()	5.1	
part_system_exists(ind)	5.1	
part_system_clear(ind)	5.1	
part_system_sprite_based(ind, set)	5.1	
part_system_draw_order(ind, oldtonew)	5.1	
part_particles_create(ind, x, y, parttype, number)	5.1	
part_particles_clear(ind)	5.1	
part_particles_count(ind)	5.1	
part_emitter_create(ps)	5.1	
part_emitter_destroy(ps, ind)	5.1	
part_emitter_destroy_all(ps)	5.1	
part_emitter_exists(ps, ind)	5.1	
part_emitter_clear(ps, ind)	5.1	
part_emitter_region(ps, ind, xmin, xmax, ymin, ymax, shape, distribution)	5.1	
part_emitter_burst(ps, ind, parttype, number)	5.1	
part_emitter_stream(ps, ind, parttype, number)	5.1	
part_attractor_create(ps)	5.1	
part_attractor_destroy(ps, ind)	5.1	
part_attractor_destroy_all(ps)	5.1	
part_attractor_exists(ps, ind)	5.1	
part_attractor_clear(ps, ind)	5.1	
part_attractor_position(ps, ind, x, y)	5.1	
part_attractor_force(ps, ind, force, dist, kind, additive)	5.1	
part_destroyer_create(ps)	5.1	
part_destroyer_destroy(ps, ind)	5.1	
part_destroyer_destroy_all(ps)	5.1	
part_destroyer_exists(ps, ind)	5.1	
part_destroyer_clear(ps, ind)	5.1	
part_destroyer_region(ps, ind, xmin, xmax, ymin, ymax, shape)	5.1	
part_deflector_create(ps)	5.1	
part_deflector_destroy(ps, ind)	5.1	
part_deflector_destroy_all(ps)	5.1	
part_deflector_exists(ps, ind)	5.1	
part_deflector_clear(ps, ind)	5.1	
part_deflector_region(ps, ind, xmin, xmax, ymin, ymax)	5.1	
part_deflector_kind(ps, kind)	5.1	
part_deflector_friction(ps, kind)	5.1	
part_changer_create(ps)	5.1	
part_changer_destroy(ps, ind)	5.1	
part_changer_destroy_all(ps)	5.1	
part_changer_exists(ps, ind)	5.1	
part_changer_clear(ps, ind)	5.1	
part_changer_region(ps, ind, xmin, xmax, ymin, ymax, shape)	5.1	
part_changer_types(ps, parttype1, parttype2)	5.1	
part_changer_kind(ps, kind)	5.1	

Deprecated functions:
path_set_end(ind, val)	5.1	5.2
set_graphics_mode(exclusive, horres, coldepth, freq, fullscreen, winscale, fullscale)	5.1	5.3a
sprite_set_transparent(ind, transp)	5.1	5.3a
sprite_set_videomem(ind, mode)	5.1	5.3a
sprite_set_loadonuse(ind, mode)	5.1	5.3a
sprite_mirror(ind)	5.1	5.3a
sprite_flip(ind)	5.1	5.3a
sprite_shift(ind, x, y)	5.1	5.3a
sprite_rotate180(ind)	5.1	5.3a
sprite_rotate90(ind, clockwise, resize)	5.1	5.3a
sprite_rotate(ind, angle, quality)	5.1	5.3a
sprite_resize(ind, w, h, corner)	5.1	5.3a
sprite_stretch(ind, w, h, quality)	5.1	5.3a
sprite_scale(ind, xscale, yscale, quality, corner, resize)	5.1	5.3a
sprite_black_white(ind)	5.1	5.3a
sprite_set_hue(ind, amount)	5.1	5.3a
sprite_change_value(ind, amount)	5.1	5.3a
sprite_change_saturation(ind, amount)	5.1	5.3a
sprite_fade(ind, col, amount)	5.1	5.3a
sprite_screendoor(ind, amount)	5.1	5.3a
sprite_blur(ind, amount)	5.1	5.3a
background_set_transparent(ind, transp)	5.1	5.3a
background_set_videomem(ind, mode)	5.1	5.3a
background_set_loadonuse(ind, mode)	5.1	5.3a
background_mirror(ind)	5.1	5.3a
background_flip(ind)	5.1	5.3a
background_shift(ind, x, y)	5.1	5.3a
background_rotate180(ind)	5.1	5.3a
background_rotate90(ind, clockwise, resize)	5.1	5.3a
background_rotate(ind, angle, quality)	5.1	5.3a
background_resize(ind, w, h, corner)	5.1	5.3a
background_stretch(ind, w, h, quality)	5.1	5.3a
background_scale(ind, xscale, yscale, quality, corner, resize)	5.1	5.3a
background_black_white(ind)	5.1	5.3a
background_set_hue(ind, amount)	5.1	5.3a
background_change_value(ind, amount)	5.1	5.3a
background_change_saturation(ind, amount)	5.1	5.3a
background_fade(ind, col, amount)	5.1	5.3a
background_screendoor(ind, amount)	5.1	5.3a
background_blur(ind, amount)	5.1	5.3a
part_type_color(ind, color_start, color_middle, color_end)	5.1	6.0
part_system_doastep(ind)	5.1	6.0
part_system_draw(ind, x, y)	5.1	6.0
sprite_create_from_screen(left, top, right, bottom, precise, transparent, videomem, loadonuse, xorig, yorig)	5.1	7.0
sprite_add_from_screen(ind, left, top, right, bottom)	5.1	7.0
sprite_set_bbox_mode(ind, mode)	5.1	7.0
sprite_set_bbox(ind, left, top, right, bottom)	5.1	7.0
sprite_set_precise(ind, mode)	5.1	7.0
background_create_from_screen(left, top, right, bottom, transparent, videomem, loadonuse)	5.1	7.0

*/

public interface IGMv51Functions
{
}
