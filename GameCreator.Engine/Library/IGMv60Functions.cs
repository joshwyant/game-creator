using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
background_get_preload(ind)	6.0	7.0
background_get_smooth(ind)	6.0	7.0
sprite_get_preload(ind)	6.0	7.0
sprite_get_smooth(ind)	6.0	7.0
move_wrap(hor, vert, margin)	6.0	
keyboard_check_pressed(key)	6.0	
keyboard_check_released(key)	6.0	
mouse_check_button_pressed(numb)	6.0	
mouse_check_button_released(numb)	6.0	
draw_sprite_general(sprite, subimg, left, top, right, bottom, x, y, xscale, yscale, rot, c1, c2, c3, c4, alpha)	6.0	
draw_background_general(back, left, top, right, bottom, x, y, xscale, yscale, rot, c1, c2, c3, c4, alpha)	6.0	
draw_clear(col)	6.0	
draw_rectangle(x1, y1, x2, y2, outline)	6.0	
draw_roundrect(x1, y1, x2, y2, outline)	6.0	
draw_triangle(x1, y1, x2, y2, x3, y3, outline)	6.0	
draw_circle(x, y, r, outline)	6.0	
draw_ellipse(x1, y1, x2, y2, outline)	6.0	
draw_set_color(col)	6.0	
draw_set_alpha(alpha)	6.0	
draw_get_color()	6.0	
draw_get_alpha()	6.0	
draw_set_font(font)	6.0	
draw_set_halign(halign)	6.0	
draw_set_valign(valign)	6.0	
draw_text_transformed(x, y, string, xscale, yscale, angle)	6.0	
draw_text_ext_transformed(x, y, string, sep, w, xscale, yscale, angle)	6.0	
draw_text_color(x, y, string, c1, c2, c3, c4, alpha)	6.0	
draw_text_ext_color(x, y, string, sep, w, c1, c2, c3, c4, alpha)	6.0	
draw_text_transformed_color(x, y, string, sep, w, c1, c2, c3, c4, alpha)	6.0	
draw_text_ext_transformed_color(x, y, string, sep, w, xscale, yscale, angle, c1, c2, c3, c4, alpha)	6.0	
draw_point_color(x, y, col1)	6.0	
draw_line_color(x1, y1, x2, y2, col1, col2)	6.0	
draw_rectangle_color(x1, y1, x2, y2, col1, col2, col3, col4, outline)	6.0	
draw_roundrect_color(x1, y1, x2, y2, col1, col2, outline)	6.0	
draw_triangle_color(x1, y1, x2, y2, x3, y3, col1, col2, col3, outline)	6.0	
draw_circle_color(x, y, r, col1, col2, outline)	6.0	
draw_ellipse_color(x1, y1, x2, y2, col1, col2, outline)	6.0	
draw_primitive_begin(kind)	6.0	
draw_vertex(x, y)	6.0	
draw_vertex_color(x, y, col, alpha)	6.0	
draw_primitive_end()	6.0	
sprite_get_texture(spr, subimg)	6.0	
background_get_texture(back)	6.0	
texture_preload(texid)	6.0	
texture_set_priority(texid, prio)	6.0	
texture_get_width(texid)	6.0	
texture_get_height(texid)	6.0	
draw_primitive_begin_texture(kind, texid)	6.0	
draw_vertex_texture(x, y, xtex, ytex)	6.0	
draw_vertex_texture_color(x, y, xtex, ytex, col, alpha)	6.0	
texture_set_interpolation(linear)	6.0	
texture_set_blending(blend)	6.0	
texture_set_repeat(repeat)	6.0	
draw_set_blend_mode(mode)	6.0	
draw_set_blend_mode_ext(src, dest)	6.0	
tile_get_blend(id)	6.0	
tile_set_blend(id, color)	6.0	
display_get_width()	6.0	
display_get_height()	6.0	
display_get_colordepth()	6.0	
display_mouse_set(x, y)	6.0	
display_mouse_get_y()	6.0	
display_mouse_get_x()	6.0	
display_reset()	6.0	
display_test_all(w, h, frequency, coldepth)	6.0	
display_set_all(w, h, frequency, coldepth)	6.0	
display_set_colordepth(coldepth)	6.0	
display_set_frequency(frequency)	6.0	
display_get_frequency()	6.0	
display_set_size(w, h)	6.0	
d3d_vertex_normal_texture_color(x, y, z, nx, ny, nz, xtex, ytex, col, alpha)	6.0	
d3d_vertex_normal_texture(x, y, z, nx, ny, nz, xtex, ytex)	6.0	
d3d_vertex_normal_color(x, y, z, nx, ny, nz, col, alpha)	6.0	
d3d_vertex_normal(x, y, z, nx, ny, nz)	6.0	
d3d_light_enable(ind, enable)	6.0	
d3d_light_define_point(ind, x, y, z, range, col)	6.0	
d3d_light_define_direction(ind, dx, dy, dz, col)	6.0	
d3d_set_shading(smooth)	6.0	
d3d_set_lighting(enable)	6.0	
d3d_set_fog(enable, color, start, end)	6.0	
d3d_transform_stack_discard()	6.0	
d3d_transform_stack_top()	6.0	
d3d_transform_stack_pop()	6.0	
3d_transform_stack_push()	6.0	
d3d_transform_stack_empty()	6.0	
d3d_transform_stack_clear()	6.0	
d3d_transform_add_rotation_axis(xa, ya, za, angle)	6.0	
d3d_transform_add_rotation_z(angle)	6.0	
d3d_transform_add_rotation_y(angle)	6.0	
d3d_transform_add_rotation_x(angle)	6.0	
d3d_transform_add_scaling(xs, ys, zs)	6.0	
d3d_transform_add_translation(xs, ys, zs)	6.0	
d3d_transform_set_rotation_axis(xa, ya, za, angle)	6.0	
d3d_transform_set_rotation_z(angle)	6.0	
d3d_transform_set_rotation_y(angle)	6.0	
d3d_transform_set_rotation_x(angle)	6.0	
d3d_transform_set_scaling(xs, ys, zs)	6.0	
d3d_transform_set_translation(xt, yt, zt)	6.0	
d3d_transform_set_identity()	6.0	
d3d_set_projection_ortho(x, y, w, h, angle)	6.0	
d3d_set_projection_ext(xfrom, yfrom, zfrom, xto, yto, zto, xup, yup, zup, angle, aspeect, znear, zfar)	6.0	
d3d_set_projection(xfrom, yfrom, zfrom, xto, yto, zto, xup, yup, zup)	6.0	
3d_draw_floor(x1, y1, z1, x2, y2, z2, texid, hrepeat, vrepeat)	6.0	
3d_draw_wall(x1, y1, z1, x2, y2, z2, texid, hrepeat, vrepeat)	6.0	
d3d_draw_ellipsoid(x1, y1, z1, x2, y2, z2, texid, hrepeat, vrepeat, steps)	6.0	
d3d_draw_cylinder(x1, y1, z1, x2, y2, z2, texid, hrepeat, vrepeat, closed, steps)	6.0	
d3d_draw_block(x1, y1, z1, x2, y2, z2, texid, hrepeat, vrepeat)	6.0	
d3d_set_culling(cull)	6.0	
d3d_primitive_end()	6.0	
d3d_vertex_texture_color(x, y, z, xtex, ytex, col, alpha)	6.0	
d3d_vertex_texture(x, y, z, xtex, ytex)	6.0	
d3d_primitive_begin_texture(kind, texid)	6.0	
d3d_primitive_end()	6.0	
d3d_vertex_color(x, y, z, col, alpha)	6.0	
d3d_vertex(x, y, z)	6.0	
d3d_primitive_begin(kind)	6.0	
d3d_set_depth(depth)	6.0	
d3d_set_perspective(enable)	6.0	
d3d_set_hidden(enable)	6.0	
d3d_end()	6.0	
d3d_start()	6.0	
part_type_alpha2(ind, alpha_start, alpha_end)	6.0	
part_type_alpha(ind, alpha_start, alpha_middle, alpha_end)	6.0	
room_assign(ind, room)	6.0	
font_delete(ind)	6.0	
font_replace_sprite(ind, spr, first, prop, sep)	6.0	
font_replace(ind, name, size, bold, italic, first, last)	6.0	
font_add_sprite(spr, first, prop, sep)	6.0	
font_add(name, size, bold, italic, first, last)	6.0	
background_create_gradient(w, h, col1, col2, kind, preload)	6.0	
background_create_color(w, h, color, preload)	6.0	
background_assign(ind, back)	6.0	
background_set_alpha_from_background(ind, back)	6.0	
sprite_set_alpha_from_sprite(ind, spr)	6.0	
sprite_assign(ind, spr)	6.0	
font_get_last(ind)	6.0	
font_get_first(ind)	6.0	
font_get_italic(ind)	6.0	
font_get_bold(ind)	6.0	
font_get_fontname(ind)	6.0	
font_get_name(ind)	6.0	
font_exists(ind)	6.0	
sound_get_preload(ind)	6.0	
highscore_set_strings(caption, nobody, escape)	6.0	
highscore_set_colors(back, new, other)	6.0	
highscore_set_font(name, size, style)	6.0	
highscore_set_border(show)	6.0	
highscore_set_background(back)	6.0	
sound_3d_set_sound_cone(snd, x, y, z, anglein, angleout, voloutside)	6.0	
sound_3d_set_sound_distance(snd, mindist, maxdist)	6.0	
sound_3d_set_sound_velocity(snd, x, y, z)	6.0	
sound_3d_set_sound_position(snd, x, y, z)	6.0	
sound_effect_equalizer(snd, center, bandwidth, gain)	6.0	
sound_effect_compressor(snd, gain, attack, release, threshold, ratio, delay)	6.0	
sound_effect_reverb(snd, gain, mix, time, ratio)	6.0	
sound_effect_gargle(snd, rate, wave)	6.0	
sound_effect_flanger(snd, wetdry, depth, feedback, frequency, wave, delay, phase)	6.0	
sound_effect_echo(snd, wetdry, feedback, leftdelay, rightdelay, pandelay)	6.0	
sound_effect_chorus(snd, wetdry, depth, feedback, frequency, wave, delay, phase)	6.0	
sound_effect_set(snd, effect)	6.0	
sound_set_search_directory(dir)	6.0	
sound_fade(index, value, time)	6.0	
sound_background_tempo(factor)	6.0	
sound_global_volume(value)	6.0	
set_synchronization(value)	6.0	
set_automatic_draw(value)	6.0	
window_views_mouse_set(x, y)	6.0	
window_views_mouse_get_y()	6.0	
window_views_mouse_get_x()	6.0	
window_view_mouse_set(id, x, y)	6.0	
window_view_mouse_get_y(id)	6.0	
window_view_mouse_get_x(id)	6.0	
window_get_region_height()	6.0	
window_get_region_width()	6.0	
window_set_region_size(w, h, adaptwindow)	6.0	
window_mouse_set(x, y)	6.0	
window_mouse_get_y()	6.0	
window_mouse_get_x()	6.0	
window_get_height()	6.0	
window_get_width()	6.0	
window_get_y()	6.0	
window_get_x()	6.0	
window_default()	6.0	
window_center()	6.0	
window_set_rectangle(x, y, w, h)	6.0	
window_set_size(w, h)	6.0	
window_set_position(x, y)	6.0	
window_get_region_scale()	6.0	
window_set_region_scale(scale, adaptwindow)	6.0	
window_get_color(color)	6.0	
window_set_color(color)	6.0	
window_get_cursor()	6.0	
window_set_cursor(curs)	6.0	
window_get_caption()	6.0	
window_set_caption(caption)	6.0	
window_get_sizeable()	6.0	
window_set_sizeable(sizeable)	6.0	
window_get_stayontop()	6.0	
window_set_stayontop(stay)	6.0	
window_get_showicons()	6.0	
window_set_showicons(show)	6.0	
window_get_showborder()	6.0	
window_set_showborder(show)	6.0	
window_get_fullscreen()	6.0	
window_set_fullscreen(full)	6.0	
window_get_visible()	6.0	
window_set_visible(visible)	6.0	

*/

