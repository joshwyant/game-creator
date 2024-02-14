using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
background_replace_alpha(ind, fname, preload)	7.0	7.0
background_add_alpha(fname, preload)	7.0	7.0
sprite_replace_alpha(ind, fname, imgnumb, precise, preload, xorig, yorig)	7.0	7.0
sprite_add_alpha(fname, imgnumb, precise, preload, xorig, yorig)	7.0	7.0
discard_include_file(fname)	7.0	
export_include_file_location(fname, location)	7.0	
export_include_file(fname)	7.0	
draw_set_circle_precision(precision)	7.0	
ds_grid_read(id, str)	7.0	
ds_grid_write(id)	7.0	
ds_grid_shuffle(id)	7.0	
ds_grid_copy(id, source)	7.0	
ds_priority_read(id, str)	7.0	
ds_priority_write(id)	7.0	
ds_priority_copy(id, source)	7.0	
ds_map_read(id, str)	7.0	
ds_map_write(id)	7.0	
ds_map_copy(id, source)	7.0	
ds_list_read(id, str)	7.0	
ds_list_write(id)	7.0	
ds_list_shuffle(id)	7.0	
ds_list_copy(id, source)	7.0	
ds_queue_read(id, str)	7.0	
ds_queue_write(id)	7.0	
ds_queue_copy(id, source)	7.0	
ds_stack_read(id, str)	7.0	
ds_stack_write(id)	7.0	
ds_stack_copy(id, source)	7.0	
background_save(ind, fname)	7.0	
sprite_save(ind, subimg, fname)	7.0	
draw_line_width_color(x1, y1, x2, y2, w, col1, col2)	7.0	
draw_line_width(x1, y1, x2, y2, w)	7.0	
randomize()	7.0	
random_get_seed()	7.0	
random_set_seed(seed)	7.0	
splash_set_stop_mouse(stop)	7.0	
splash_set_stop_key(stop)	7.0	
splash_set_interrupt(interrupt)	7.0	
splash_set_top(top)	7.0	
splash_set_adapt(adapt)	7.0	
splash_set_size(w, h)	7.0	
splash_set_border(border)	7.0	
splash_set_fullscreen(full)	7.0	
splash_set_caption(cap)	7.0	
splash_set_color(col)	7.0	
splash_set_cursor(vis)	7.0	
splash_set_scale(scale)	7.0	
splash_set_main(main)	7.0	
splash_show_image(fname, delay)	7.0	
splash_show_text(fname, delay)	7.0	
splash_show_video(fname, loop)	7.0	
transition_exists(kind)	7.0	
transition_define(kind, name)	7.0	

Deprecated functions:
background_replace_alpha(ind, fname, preload)	7.0	7.0
background_add_alpha(fname, preload)	7.0	7.0
sprite_replace_alpha(ind, fname, imgnumb, precise, preload, xorig, yorig)	7.0	7.0
sprite_add_alpha(fname, imgnumb, precise, preload, xorig, yorig)	7.0	7.0

*/

