using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
environment_get_variable(name)	5.2	
instance_deactivate_all(notme)	5.2	
instance_deactivate_object(obj)	5.2	
instance_deactivate_region(left, top, width, height, inside, notme)	5.2	
instance_activate_all()	5.2	
instance_activate_object(obj)	5.2	
instance_activate_region(left, top, width, height, inside)	5.2	
set_program_priority(priority)	5.2	
tile_layer_hide(depth)	5.2	
tile_layer_show(depth)	5.2	
tile_layer_delete(depth)	5.2	
tile_layer_shift(depth, x, y)	5.2	
tile_layer_find(depth, x, y)	5.2	
tile_layer_delete_at(depth, x, y)	5.2	
tile_layer_depth(depth, newdepth)	5.2	
filename_name(fname)	5.2	
filename_path(fname)	5.2	
filename_dir(fname)	5.2	
filename_drive(fname)	5.2	
filename_ext(fname)	5.2	
filename_change_ext(fname, newext)	5.2	
file_bin_open(fname, mod)	5.2	
file_bin_rewrite(fileid)	5.2	
file_bin_close(fileid)	5.2	
file_bin_size(fileid)	5.2	
file_bin_position(fileid)	5.2	
file_bin_seek(fileid, pos)	5.2	
file_bin_write_byte(fileid, byte)	5.2	
file_bin_read_byte(fileid)	5.2	
ds_set_precision(prec)	5.2	
ds_stack_create()	5.2	
ds_stack_destroy(id)	5.2	
ds_stack_clear(id)	5.2	
ds_stack_size(id)	5.2	
ds_stack_empty(id)	5.2	
ds_stack_push(id, val)	5.2	
ds_stack_pop(id)	5.2	
ds_stack_top(id)	5.2	
ds_queue_create()	5.2	
ds_queue_destroy(id)	5.2	
ds_queue_clear(id)	5.2	
ds_queue_size(id)	5.2	
ds_queue_empty(id)	5.2	
ds_queue_enqueue(id, val)	5.2	
ds_queue_dequeue(id)	5.2	
ds_queue_head(id)	5.2	
ds_queue_tail(id)	5.2	
ds_list_create()	5.2	
ds_list_destroy(id)	5.2	
ds_list_clear(id)	5.2	
ds_list_size(id)	5.2	
ds_list_empty(id)	5.2	
ds_list_add(id, val)	5.2	
ds_list_insert(id, pos, val)	5.2	
ds_list_replace(id, pos, val)	5.2	
ds_list_delete(id, pos)	5.2	
ds_list_find_index(id, val)	5.2	
ds_list_find_value(id, pos)	5.2	
ds_list_sort(id, ascend)	5.2	
ds_map_create()	5.2	
ds_map_destroy(id)	5.2	
ds_map_clear(id)	5.2	
ds_map_size(id)	5.2	
ds_map_empty(id)	5.2	
ds_map_add(id, key, val)	5.2	
ds_map_replace(id, key, val)	5.2	
ds_map_delete(id, key)	5.2	
ds_map_exists(id, key)	5.2	
ds_map_find_value(id, key)	5.2	
ds_map_find_previous(id, key)	5.2	
ds_map_find_next(id, key)	5.2	
ds_map_find_first(id)	5.2	
ds_map_find_last(id)	5.2	
ds_priority_create()	5.2	
ds_priority_destroy(id)	5.2	
ds_priority_clear(id)	5.2	
ds_priority_size(id)	5.2	
ds_priority_empty(id)	5.2	
ds_priority_add(id, val, prio)	5.2	
ds_priority_change_priority(id, val, prio)	5.2	
ds_priority_find_priority(id, val)	5.2	
ds_priority_delete_value(id, val)	5.2	
ds_priority_delete_min(id)	5.2	
ds_priority_find_min(id)	5.2	
ds_priority_delete_max(id)	5.2	
ds_priority_find_max(id)	5.2	

Deprecated functions:
mouse_set_screen_position(x, y)	5.2	5.3a

*/

public interface IGMv52Functions
{
}
