using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
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

public interface IGMv70Functions
{
    #region Deprecated functions
    [Gml("background_replace_alpha", v70, v70)]
    void BackgroundReplaceAlpha(int ind, string fname, bool preload);

    [Gml("background_add_alpha", v70, v70)]
    void BackgroundAddAlpha(string fname, bool preload);

    [Gml("sprite_replace_alpha", v70, v70)]
    void SpriteReplaceAlpha(int ind, string fname, int imgnumb, bool precise, bool preload, double xorig, double yorig);

    [Gml("sprite_add_alpha", v70, v70)]
    void SpriteAddAlpha(string fname, int imgnumb, bool precise, bool preload, double xorig, double yorig);
    #endregion

    #region Functions
    [Gml("discard_include_file", v70)]
    void DiscardIncludeFile(string fname);

    [Gml("export_include_file_location", v70)]
    void ExportIncludeFileLocation(string fname, string location);

    [Gml("export_include_file", v70)]
    void ExportIncludeFile(string fname);

    [Gml("draw_set_circle_precision", v70)]
    void DrawSetCirclePrecision(double precision);

    [Gml("ds_grid_read", v70)]
    void DsGridRead(int id, string str);

    [Gml("ds_grid_write", v70)]
    void DsGridWrite(int id);

    [Gml("ds_grid_shuffle", v70)]
    void DsGridShuffle(int id);

    [Gml("ds_grid_copy", v70)]
    void DsGridCopy(int id, int source);

    [Gml("ds_priority_read", v70)]
    void DsPriorityRead(int id, string str);

    [Gml("ds_priority_write", v70)]
    void DsPriorityWrite(int id);

    [Gml("ds_priority_copy", v70)]
    void DsPriorityCopy(int id, int source);

    [Gml("ds_map_read", v70)]
    void DsMapRead(int id, string str);

    [Gml("ds_map_write", v70)]
    void DsMapWrite(int id);

    [Gml("ds_map_copy", v70)]
    void DsMapCopy(int id, int source);

    [Gml("ds_list_read", v70)]
    void DsListRead(int id, string str);

    [Gml("ds_list_write", v70)]
    void DsListWrite(int id);

    [Gml("ds_list_shuffle", v70)]
    void DsListShuffle(int id);

    [Gml("ds_list_copy", v70)]
    void DsListCopy(int id, int source);

    [Gml("ds_queue_read", v70)]
    void DsQueueRead(int id, string str);

    [Gml("ds_queue_write", v70)]
    void DsQueueWrite(int id);

    [Gml("ds_queue_copy", v70)]
    void DsQueueCopy(int id, int source);

    [Gml("ds_stack_read", v70)]
    void DsStackRead(int id, string str);

    [Gml("ds_stack_write", v70)]
    void DsStackWrite(int id);

    [Gml("ds_stack_copy", v70)]
    void DsStackCopy(int id, int source);

    [Gml("background_save", v70)]
    void BackgroundSave(int ind, string fname);

    [Gml("sprite_save", v70)]
    void SpriteSave(int ind, int subimg, string fname);

    [Gml("draw_line_width_color", v70)]
    void DrawLineWidthColor(double x1, double y1, double x2, double y2, double w, int col1, int col2);

    [Gml("draw_line_width", v70)]
    void DrawLineWidth(double x1, double y1, double x2, double y2, double w);

    [Gml("randomize", v70)]
    void Randomize();

    [Gml("random_get_seed", v70)]
    void RandomGetSeed();

    [Gml("random_set_seed", v70)]
    void RandomSetSeed(int seed);

    [Gml("splash_set_stop_mouse", v70)]
    void SplashSetStopMouse(bool stop);

    [Gml("splash_set_stop_key", v70)]
    void SplashSetStopKey(bool stop);

    [Gml("splash_set_interrupt", v70)]
    void SplashSetInterrupt(int interrupt);

    [Gml("splash_set_top", v70)]
    void SplashSetTop(bool top);

    [Gml("splash_set_adapt", v70)]
    void SplashSetAdapt(bool adapt);

    [Gml("splash_set_size", v70)]
    void SplashSetSize(double w, double h);

    [Gml("splash_set_border", v70)]
    void SplashSetBorder(bool border);

    [Gml("splash_set_fullscreen", v70)]
    void SplashSetFullscreen(bool full);

    [Gml("splash_set_caption", v70)]
    void SplashSetCaption(string cap);

    [Gml("splash_set_color", v70)]
    void SplashSetColor(int col);

    [Gml("splash_set_cursor", v70)]
    void SplashSetCursor(bool vis);

    [Gml("splash_set_scale", v70)]
    void SplashSetScale(double scale);

    [Gml("splash_set_main", v70)]
    void SplashSetMain(bool main);

    [Gml("splash_show_image", v70)]
    void SplashShowImage(string fname, double delay);

    [Gml("splash_show_text", v70)]
    void SplashShowText(string fname, double delay);

    [Gml("splash_show_video", v70)]
    void SplashShowVideo(string fname, bool loop);

    [Gml("transition_exists", v70)]
    void TransitionExists(int kind);

    [Gml("transition_define", v70)]
    void TransitionDefine(int kind, string name);
    #endregion
}
