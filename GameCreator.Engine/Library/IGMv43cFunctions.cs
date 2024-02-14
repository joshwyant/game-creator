using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
sprite_get_transparent(ind)	4.3	7.0
sprite_get_precise(ind)	4.3	7.0
background_get_transparent(ind)	4.3	7.0
draw_text_ext(x, y, str, sep, w)	4.3	
string_width_ext(str, sep, w)	4.3	
string_height_ext(str, sep, w)	4.3	
object_get_parent(obj)	4.3	
object_is_ancestor(obj, anc)	4.3	
string_replace(str, substr, newstr)	4.3	
string_replace_all(str, substr, newstr)	4.3	
string_count(substr, str)	4.3	
execute_file(fname)	4.3	
sound_stop_all()	4.3	
parameter_count()	4.3	
parameter_string(ind)	4.3	
get_directory_alt(capt, root)	4.3	
sprite_exists(ind)	4.3	
sprite_get_name(ind)	4.3	
sprite_get_number(ind)	4.3	
sprite_get_width(ind)	4.3	
sprite_get_height(ind)	4.3	
sprite_get_xoffset(ind)	4.3	
sprite_get_yoffset(ind)	4.3	
sprite_get_bbox_left(ind)	4.3	
sprite_get_bbox_right(ind)	4.3	
sprite_get_bbox_top(ind)	4.3	
sprite_get_bbox_bottom(ind)	4.3	
sound_exists(ind)	4.3	
sound_get_name(ind)	4.3	
sound_get_kind(ind)	4.3	
sound_get_buffers(ind)	4.3	
sound_get_effect(ind)	4.3	
background_exists(ind)	4.3	
background_get_name(ind)	4.3	
background_get_width(ind)	4.3	
background_get_height(ind)	4.3	
path_exists(ind)	4.3	
path_get_name(ind)	4.3	
path_get_length(ind)	4.3	
path_get_kind(ind)	4.3	
script_exists(ind)	4.3	
object_exists(ind)	4.3	
object_get_name(ind)	4.3	
object_get_sprite(ind)	4.3	
object_get_solid(ind)	4.3	
object_get_visible(ind)	4.3	
object_get_depth(ind)	4.3	
object_get_persistent(ind)	4.3	
object_get_mask(ind)	4.3	
object_get_parent(ind)	4.3	
object_is_ancestor(ind1, ind2)	4.3	
room_exists(ind)	4.3	
room_get_name(ind)	4.3	
cd_init()	4.3	
cd_present()	4.3	
cd_number()	4.3	
cd_playing()	4.3	
cd_paused()	4.3	
cd_track()	4.3	
cd_track_length(n)	4.3	
cd_position()	4.3	
cd_set_position(pos)	4.3	
cd_play(first, last)	4.3	
cd_stop()	4.3	
cd_pause()	4.3	
cd_resume	4.3	
cd_set_track_position(pos)	4.3	
cd_open_door()	4.3	
cd_close_door()	4.3	
show_message_ext(str, but1, but2, but3)	4.3	
message_background(back)	4.3	
message_button(spr)	4.3	
message_text_font(name, size, color, style)	4.3	
message_button_font(name, size, color, style)	4.3	
message_input_font(name, size, color, style)	4.3	
message_mouse_color(col)	4.3	
message_input_color(col)	4.3	
message_caption(show, str)	4.3	
message_position(x, y)	4.3	
show_error(str, abort)	4.3	
file_find_first(mask, attr)	4.3	
file_find_next()	4.3	
file_find_close()	4.3	
file_attributes(fname, attr)	4.3	
registry_set_root(root)	4.3	
window_handle()	4.3	

*/

