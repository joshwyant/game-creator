using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
get_open_filename(filter, fname)	4.0
get_save_filename(filter, fname)	4.0
get_directory(dname)	4.0
get_color(defcolor)	4.0
real(str)	4.0
string_format(val, tot, dec)	4.0
draw_button(x1, y1, x2, y2, up)	4.0
motion_set(dir, speed)	4.0
motion_add(dir, speed)	4.0
place_free(x, y)	4.0
place_empty(x, y)	4.0
place_meeting(x, y, obj)	4.0
place_snapped(hsnap, vsnap)	4.0
move_random(hsnap, vsnap)	4.0
move_snap(hsnap, vsnap)	4.0
move_towards_point(x, y, sp)	4.0
move_bounce_solid(adv)	4.0
move_bounce_all(adv)	4.0
move_contact(dir)	4.0
position_empty(x, y)	4.0
position_meeting(x, y, obj)	4.0
instance_find(obj, n)	4.0
instance_exists(obj)	4.0
instance_number(obj)	4.0
instance_position(x, y, obj)	4.0
instance_nearest(x, y, obj)	4.0
instance_furthest(x, y, obj)	4.0
instance_place(x, y, obj)	4.0
instance_create(x, y, obj)	4.0
instance_destroy()	4.0
instance_change(obj, perf)	4.0
position_destroy(x, y)	4.0
position_change(x, y, obj, perf)	4.0
room_goto(numb)	4.0
room_goto_previous()	4.0
room_goto_next()	4.0
room_restart()	4.0
room_previous(numb)	4.0
room_next(numb)	4.0
game_end()	4.0
game_restart()	4.0
game_save(string)	4.0
game_load(string)	4.0
event_perform(type, numb)	4.0
event_perform_object(obj, type, numb)	4.0
event_user(numb)	4.0
keyboard_check(key)	4.0
keyboard_check_direct(key)	4.0
mouse_check_button(numb)	4.0
keyboard_clear(key)	4.0
mouse_clear(button)	4.0
io_clear()	4.0
io_handle()	4.0
keyboard_wait()	4.0
joystick_exists(id)	4.0
joystick_direction(id)	4.0
joystick_check_button(id, numb)	4.0
joystick_xpos(id)	4.0
joystick_ypos(id)	4.0
joystick_zpos(id)	4.0
sprite_discard(numb)	4.0
sprite_restore(numb)	4.0
discard_all()	4.0
background_discard(numb)	4.0
background_restore(numb)	4.0
draw_sprite(n, img, x, y)	4.0
draw_sprite_scaled(n, img, x, y, s)	4.0
draw_sprite_stretched(n, img, x, y, w, h)	4.0
draw_background(n, x, y)	4.0
draw_background_scaled(n, x, y, s)	4.0
draw_background_stretched(n, x, y, s, alpha)	4.0
draw_background_tiled(n, x, y)	4.0
screen_save(fname)	4.0
screen_save_part(fname, left, top, right, bottom)	4.0
screen_redraw()	4.0
screen_refresh()	4.0
sound_isplaying(index)	4.0
sound_discard(index)	4.0
sound_restore(index)	4.0
show_menu(str, def)	4.0
directory_exists(dname)	4.0
directory_create(dname)	4.0
registry_write_string(name, str)	4.0
registry_write_real(name, x)	4.0
registry_read_string(name)	4.0
registry_read_real(name)	4.0
registry_exists(name)	4.0
registry_read_string_ext(key, name)	4.0
registry_read_real_ext(key, name)	4.0
registry_exists_ext(key, name)	4.0
execute_program(prog, arg, wait)	4.0
execute_shell(prog, arg)	4.0
make_color(red, green, blue)	4.0

Deprecated functions:
background_replace(ind, fname)	4.0	4.0
external_call0(id)	4.0	4.3
external_call1(id)	4.0	4.3
external_call2(id)	4.0	4.3
draw_sprite_transparent(n, img, x, y, s, alpha)	4.0	5.0
draw_background_transparent(n, x, y, s, alpha)	4.0	5.0
draw_pixel(x, y)	4.0	5.3a
draw_fill(x, y)	4.0	5.3a
draw_arc(x1, y1, x2, y2, x3, y3, x4, y4)	4.0	5.3a
draw_chord(x1, y1, x2, y2, x3, y3, x4, y4)	4.0	5.3a
draw_pie(x1, y1, x2, y2, x3, y3, x4, y4)	4.0	5.3a
screen_gamma(r, g, b)	4.0	5.3a
external_define0(dll, name, restype)	4.0
external_define1(dll, name, arg1type, restype)	4.0
external_define2(dll, name, arg1type, arg2type, restype)	4.0

*/

public interface IGMv40Functions
{
}