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
    #region Functions
    [Gml("environment_get_variable", v52)]
    string EnvironmentGetVariable(string name);

    [Gml("instance_deactivate_all", v52)]
    void InstanceDeactivateAll(bool notme);

    [Gml("instance_deactivate_object", v52)]
    void InstanceDeactivateObject(int obj);

    [Gml("instance_deactivate_region", v52)]
    void InstanceDeactivateRegion(double left, double top, double width, double height, bool inside, bool notme);

    [Gml("instance_activate_all", v52)]
    void InstanceActivateAll();

    [Gml("instance_activate_object", v52)]
    void InstanceActivateObject(int obj);

    [Gml("instance_activate_region", v52)]
    void InstanceActivateRegion(double left, double top, double width, double height, bool inside);

    [Gml("set_program_priority", v52)]
    void SetProgramPriority(int priority);

    [Gml("tile_layer_hide", v52)]
    void TileLayerHide(double depth);

    [Gml("tile_layer_show", v52)]
    void TileLayerShow(double depth);

    [Gml("tile_layer_delete", v52)]
    void TileLayerDelete(double depth);

    [Gml("tile_layer_shift", v52)]
    void TileLayerShift(double depth, double x, double y);

    [Gml("tile_layer_find", v52)]
    int TileLayerFind(double depth, double x, double y);

    [Gml("tile_layer_delete_at", v52)]
    void TileLayerDeleteAt(double depth, double x, double y);

    [Gml("tile_layer_depth", v52)]
    void TileLayerDepth(double depth, double newdepth);

    [Gml("filename_name", v52)]
    string FilenameName(string fname);

    [Gml("filename_path", v52)]
    string FilenamePath(string fname);

    [Gml("filename_dir", v52)]
    string FilenameDir(string fname);

    [Gml("filename_drive", v52)]
    string FilenameDrive(string fname);

    [Gml("filename_ext", v52)]
    string FilenameExt(string fname);

    [Gml("filename_change_ext", v52)]
    string FilenameChangeExt(string fname, string newext);

    [Gml("file_bin_open", v52)]
    int FileBinOpen(string fname, int mod);

    [Gml("file_bin_rewrite", v52)]
    void FileBinRewrite(int fileid);

    [Gml("file_bin_close", v52)]
    void FileBinClose(int fileid);

    [Gml("file_bin_size", v52)]
    int FileBinSize(int fileid);

    [Gml("file_bin_position", v52)]
    int FileBinPosition(int fileid);

    [Gml("file_bin_seek", v52)]
    void FileBinSeek(int fileid, int pos);

    [Gml("file_bin_write_byte", v52)]
    void FileBinWriteByte(int fileid, int val);

    [Gml("file_bin_read_byte", v52)]
    int FileBinReadByte(int fileid);

    [Gml("ds_set_precision", v52)]
    void DsSetPrecision(int prec);

    [Gml("ds_stack_create", v52)]
    int DsStackCreate();

    [Gml("ds_stack_destroy", v52)]
    void DsStackDestroy(int id);

    [Gml("ds_stack_clear", v52)]
    void DsStackClear(int id);

    [Gml("ds_stack_size", v52)]
    int DsStackSize(int id);

    [Gml("ds_stack_empty", v52)]
    bool DsStackEmpty(int id);

    [Gml("ds_stack_push", v52)]
    void DsStackPush(int id, double val);

    [Gml("ds_stack_pop", v52)]
    double DsStackPop(int id);

    [Gml("ds_stack_top", v52)]
    double DsStackTop(int id);

    [Gml("ds_queue_create", v52)]
    int DsQueueCreate();

    [Gml("ds_queue_destroy", v52)]
    void DsQueueDestroy(int id);

    [Gml("ds_queue_clear", v52)]
    void DsQueueClear(int id);

    [Gml("ds_queue_size", v52)]
    int DsQueueSize(int id);

    [Gml("ds_queue_empty", v52)]
    bool DsQueueEmpty(int id);

    [Gml("ds_queue_enqueue", v52)]
    void DsQueueEnqueue(int id, double val);

    [Gml("ds_queue_dequeue", v52)]
    double DsQueueDequeue(int id);

    [Gml("ds_queue_head", v52)]
    double DsQueueHead(int id);

    [Gml("ds_queue_tail", v52)]
    double DsQueueTail(int id);

    [Gml("ds_list_create", v52)]
    int DsListCreate();

    [Gml("ds_list_destroy", v52)]
    void DsListDestroy(int id);

    [Gml("ds_list_clear", v52)]
    void DsListClear(int id);

    [Gml("ds_list_size", v52)]
    int DsListSize(int id);

    [Gml("ds_list_empty", v52)]
    bool DsListEmpty(int id);

    [Gml("ds_list_add", v52)]
    void DsListAdd(int id, double val);

    [Gml("ds_list_insert", v52)]
    void DsListInsert(int id, int pos, double val);

    [Gml("ds_list_replace", v52)]
    void DsListReplace(int id, int pos, double val);

    [Gml("ds_list_delete", v52)]
    void DsListDelete(int id, int pos);

    [Gml("ds_list_find_index", v52)]
    int DsListFindIndex(int id, double val);

    [Gml("ds_list_find_value", v52)]
    double DsListFindValue(int id, int pos);

    [Gml("ds_list_sort", v52)]
    void DsListSort(int id, bool ascend);

    [Gml("ds_map_create", v52)]
    int DsMapCreate();

    [Gml("ds_map_destroy", v52)]
    void DsMapDestroy(int id);

    [Gml("ds_map_clear", v52)]
    void DsMapClear(int id);

    [Gml("ds_map_size", v52)]
    int DsMapSize(int id);

    [Gml("ds_map_empty", v52)]
    bool DsMapEmpty(int id);

    [Gml("ds_map_add", v52)]
    void DsMapAdd(int id, string key, double val);

    [Gml("ds_map_replace", v52)]
    void DsMapReplace(int id, string key, double val);

    [Gml("ds_map_delete", v52)]
    void DsMapDelete(int id, string key);

    [Gml("ds_map_exists", v52)]
    bool DsMapExists(int id, string key);

    [Gml("ds_map_find_value", v52)]
    double DsMapFindValue(int id, string key);

    [Gml("ds_map_find_previous", v52)]
    string DsMapFindPrevious(int id, string key);

    [Gml("ds_map_find_next", v52)]
    string DsMapFindNext(int id, string key);

    [Gml("ds_map_find_first", v52)]
    string DsMapFindFirst(int id);

    [Gml("ds_map_find_last", v52)]
    string DsMapFindLast(int id);

    [Gml("ds_priority_create", v52)]
    int DsPriorityCreate();

    [Gml("ds_priority_destroy", v52)]
    void DsPriorityDestroy(int id);

    [Gml("ds_priority_clear", v52)]
    void DsPriorityClear(int id);

    [Gml("ds_priority_size", v52)]
    int DsPrioritySize(int id);

    [Gml("ds_priority_empty", v52)]
    bool DsPriorityEmpty(int id);

    [Gml("ds_priority_add", v52)]
    void DsPriorityAdd(int id, double val, double prio);

    [Gml("ds_priority_change_priority", v52)]
    void DsPriorityChangePriority(int id, double val, double prio);

    [Gml("ds_priority_find_priority", v52)]
    double DsPriorityFindPriority(int id, double val);

    [Gml("ds_priority_delete_value", v52)]
    void DsPriorityDeleteValue(int id, double val);

    [Gml("ds_priority_delete_min", v52)]
    void DsPriorityDeleteMin(int id);

    [Gml("ds_priority_find_min", v52)]
    double DsPriorityFindMin(int id);

    [Gml("ds_priority_delete_max", v52)]
    void DsPriorityDeleteMax(int id);

    [Gml("ds_priority_find_max", v52)]
    double DsPriorityFindMax(int id);
    #endregion

    #region Deprecated functions
    [Gml("mouse_set_screen_position", v52, v53a)]
    void MouseSetScreenPosition(double x, double y);
    #endregion

}   
