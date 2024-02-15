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
sound_delete(index)	5.1	
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
    #region Deprecated functions
    [Gml("path_set_end", v51, v52)]
    void PathSetEnd(int ind, int val);

    [Gml("set_graphics_mode", v51, v53a)]
    void SetGraphicsMode(bool exclusive, int horres, int coldepth, int freq, bool fullscreen, int winscale, int fullscale);

    [Gml("sprite_set_transparent", v51, v53a)]
    void SpriteSetTransparent(int ind, int transp);

    [Gml("sprite_set_videomem", v51, v53a)]
    void SpriteSetVideomem(int ind, int mode);

    [Gml("sprite_set_loadonuse", v51, v53a)]
    void SpriteSetLoadonuse(int ind, int mode);

    [Gml("sprite_mirror", v51, v53a)]
    void SpriteMirror(int ind);

    [Gml("sprite_flip", v51, v53a)]
    void SpriteFlip(int ind);

    [Gml("sprite_shift", v51, v53a)]
    void SpriteShift(int ind, double x, double y);

    [Gml("sprite_rotate180", v51, v53a)]
    void SpriteRotate180(int ind);

    [Gml("sprite_rotate90", v51, v53a)]
    void SpriteRotate90(int ind, bool clockwise, bool resize);

    [Gml("sprite_rotate", v51, v53a)]
    void SpriteRotate(int ind, double angle, int quality);

    [Gml("sprite_resize", v51, v53a)]
    void SpriteResize(int ind, double w, double h, int corner);

    [Gml("sprite_stretch", v51, v53a)]
    void SpriteStretch(int ind, double w, double h, int quality);

    [Gml("sprite_scale", v51, v53a)]
    void SpriteScale(int ind, double xscale, double yscale, int quality, int corner, bool resize);

    [Gml("sprite_black_white", v51, v53a)]
    void SpriteBlackWhite(int ind);

    [Gml("sprite_set_hue", v51, v53a)]
    void SpriteSetHue(int ind, int amount);

    [Gml("sprite_change_value", v51, v53a)]
    void SpriteChangeValue(int ind, int amount);

    [Gml("sprite_change_saturation", v51, v53a)]
    void SpriteChangeSaturation(int ind, int amount);

    [Gml("sprite_fade", v51, v53a)]
    void SpriteFade(int ind, int col, int amount);

    [Gml("sprite_screendoor", v51, v53a)]
    void SpriteScreendoor(int ind, int amount);

    [Gml("sprite_blur", v51, v53a)]
    void SpriteBlur(int ind, int amount);

    [Gml("background_set_transparent", v51, v53a)]
    void BackgroundSetTransparent(int ind, int transp);

    [Gml("background_set_videomem", v51, v53a)]
    void BackgroundSetVideomem(int ind, int mode);

    [Gml("background_set_loadonuse", v51, v53a)]
    void BackgroundSetLoadonuse(int ind, int mode);

    [Gml("background_mirror", v51, v53a)]
    void BackgroundMirror(int ind);

    [Gml("background_flip", v51, v53a)]
    void BackgroundFlip(int ind);

    [Gml("background_shift", v51, v53a)]
    void BackgroundShift(int ind, double x, double y);

    [Gml("background_rotate180", v51, v53a)]
    void BackgroundRotate180(int ind);

    [Gml("background_rotate90", v51, v53a)]
    void BackgroundRotate90(int ind, bool clockwise, bool resize);

    [Gml("background_rotate", v51, v53a)]
    void BackgroundRotate(int ind, double angle, int quality);

    [Gml("background_resize", v51, v53a)]
    void BackgroundResize(int ind, double w, double h, int corner);

    [Gml("background_stretch", v51, v53a)]
    void BackgroundStretch(int ind, double w, double h, int quality);

    [Gml("background_scale", v51, v53a)]
    void BackgroundScale(int ind, double xscale, double yscale, int quality);

    [Gml("background_black_white", v51, v53a)]
    void BackgroundBlackWhite(int ind);

    [Gml("background_set_hue", v51, v53a)]
    void BackgroundSetHue(int ind, int amount);

    [Gml("background_change_value", v51, v53a)]
    void BackgroundChangeValue(int ind, int amount);

    [Gml("background_change_saturation", v51, v53a)]
    void BackgroundChangeSaturation(int ind, int amount);

    [Gml("background_fade", v51, v53a)]
    void BackgroundFade(int ind, int col, int amount);

    [Gml("background_screendoor", v51, v53a)]
    void BackgroundScreendoor(int ind, int amount);

    [Gml("background_blur", v51, v53a)]
    void BackgroundBlur(int ind, int amount);

    [Gml("part_type_color", v51, v60)]
    void PartTypeColor(int ind, int color_start, int color_middle, int color_end);

    [Gml("part_system_doastep", v51, v60)]
    void PartSystemDoastep(int ind);

    [Gml("sprite_create_from_screen", v51, v70)]
    int SpriteCreateFromScreen(int left, int top, int right, int bottom, bool precise, bool transparent, bool videomem, bool loadonuse, int xorig, int yorig);

    [Gml("sprite_add_from_screen", v51, v70)]
    int SpriteAddFromScreen(int ind, int left, int top, int right, int bottom);

    [Gml("sprite_set_bbox_mode", v51, v70)]
    void SpriteSetBboxMode(int ind, int mode);

    [Gml("sprite_set_bbox", v51, v70)]
    void SpriteSetBbox(int ind, int left, int top, int right, int bottom);

    [Gml("sprite_set_precise", v51, v70)]
    void SpriteSetPrecise(int ind, int mode);

    [Gml("background_create_from_screen", v51, v70)]
    int BackgroundCreateFromScreen(int left, int top, int right, int bottom, bool transparent, bool videomem, bool loadonuse);
    #endregion

    [Gml("push_graphics_settings", v51)]
    void PushGraphicsSettings();

    [Gml("pop_graphics_settings", v51)]
    void PopGraphicsSettings();

    [Gml("external_free", v51)]
    void ExternalFree(int dll);

    [Gml("lengthdir_x", v51)]
    double LengthdirX(double len, double dir);

    [Gml("lengthdir_y", v51)]
    double LengthdirY(double len, double dir);

    [Gml("variable_global_exists", v51)]
    bool VariableGlobalExists(string name);

    [Gml("variable_local_exists", v51)]
    bool VariableLocalExists(string name);

    [Gml("variable_global_get", v51)]
    object VariableGlobalGet(string name);

    [Gml("variable_global_set", v51)]
    void VariableGlobalSet(string name, object value);

    [Gml("variable_local_set", v51)]
    void VariableLocalSet(string name, object value);

    [Gml("mouse_wait", v51)]
    void MouseWait();

    [Gml("draw_sprite_tiled_ext", v51)]
    void DrawSpriteTiledExt(int n, int img, double x, double y, double xscale, double yscale, int alpha);

    [Gml("draw_sprite_part", v51)]
    void DrawSpritePart(int n, int img, int left, int top, int right, int bottom, double x, double y);

    [Gml("draw_sprite_part_ext", v51)]
    void DrawSpritePartExt(int n, int img, int left, int top, int right, int bottom, double x, double y, double xscale, double yscale, int alpha);

    [Gml("draw_sprite_part_alpha", v51)]
    void DrawSpritePartAlpha(int n, int img, int left, int top, int right, int bottom, double x, double y, double xscale, double yscale, int alphaspr, int ind);

    [Gml("draw_sprite_stretched_ext", v51)]
    void DrawSpriteStretchedExt(int n, int img, double x, double y, double w, double h, int alpha);

    [Gml("draw_sprite_alpha", v51)]
    void DrawSpriteAlpha(int n, int img, double x, double y, double xscale, double yscale, int alphaspr, int ind);

    [Gml("draw_background_ext", v51)]
    void DrawBackgroundExt(int n, double x, double y);

    [Gml("draw_background_stretched_ext", v51)]
    void DrawBackgroundStretchedExt(int n, double x, double y, double w, double h, int alpha);

    [Gml("draw_background_tiled_ext", v51)]
    void DrawBackgroundTiledExt(int n, double x, double y, double xscale, double yscale, int alpha);

    [Gml("draw_background_part", v51)]
    void DrawBackgroundPart(int n, int left, int top, int right, int bottom, double x, double y);

    [Gml("draw_background_part_ext", v51)]
    void DrawBackgroundPartExt(int n, int left, int top, int right, int bottom, double x, double y, double xscale, double yscale, int alpha);

    [Gml("draw_background_alpha", v51)]
    void DrawBackgroundAlpha(int n, double x, double y, double xscale, double yscale, int alphaback);

    [Gml("draw_background_part_alpha", v51)]
    void DrawBackgroundPartAlpha(int n, int left, int top, int right, int bottom, double x, double y, double xscale, double yscale, int alphaback);

    [Gml("draw_arrow", v51)]
    void DrawArrow(double x1, double y1, double x2, double y2, double size);

    [Gml("message_alpha", v51)]
    void MessageAlpha(int alpha);

    [Gml("sprite_get_bbox_mode", v51)]
    int SpriteGetBboxMode(int ind);

    [Gml("sprite_set_offset", v51)]
    void SpriteSetOffset(int ind, double xoff, double yoff);

    [Gml("sprite_duplicate", v51)]
    int SpriteDuplicate(int ind);

    [Gml("sprite_merge", v51)]
    int SpriteMerge(int ind1, int ind2);

    [Gml("sound_add", v51)]
    int SoundAdd(string fname, int buffers, int effects, bool loadonuse);

    [Gml("sound_replace", v51)]
    void SoundReplace(int index, string fname, int buffers, int effects, bool loadonuse);

    [Gml("sound_delete", v51)]
    void SoundDelete(int index);

    [Gml("background_duplicate", v51)]
    int BackgroundDuplicate(int ind);

    [Gml("path_set_kind", v51)]
    void PathSetKind(int ind, int val);

    [Gml("path_add", v51)]
    int PathAdd();

    [Gml("path_delete", v51)]
    void PathDelete(int ind);

    [Gml("path_add_point", v51)]
    void PathAddPoint(int ind, double x, double y, double speed);

    [Gml("path_clear_points", v51)]
    void PathClearPoints(int ind);

    [Gml("script_execute", v51)]
    void ScriptExecute(string scr, params object[] args);

    [Gml("timeline_add", v51)]
    int TimelineAdd();

    [Gml("timeline_delete", v51)]
    void TimelineDelete(int ind);

    [Gml("timeline_moment_add", v51)]
    void TimelineMomentAdd(int ind, int step, string codestr);

    [Gml("timeline_moment_clear", v51)]
    void TimelineMomentClear(int ind, int step);

    [Gml("object_set_sprite", v51)]
    void ObjectSetSprite(int ind, int spr);

    [Gml("object_set_solid", v51)]
    void ObjectSetSolid(int ind, bool solid);

    [Gml("object_set_visible", v51)]
    void ObjectSetVisible(int ind, bool vis);

    [Gml("object_set_depth", v51)]
    void ObjectSetDepth(int ind, int depth);

    [Gml("object_set_persistent", v51)]
    void ObjectSetPersistent(int ind, bool pers);

    [Gml("object_set_mask", v51)]
    void ObjectSetMask(int ind, int spr);

    [Gml("object_set_parent", v51)]
    void ObjectSetParent(int ind, int obj);

    [Gml("object_add", v51)]
    int ObjectAdd();

    [Gml("object_delete", v51)]
    void ObjectDelete(int ind);

    [Gml("object_event_add", v51)]
    void ObjectEventAdd(int ind, int evtype, int evnumb, string codestr);

    [Gml("object_event_clear", v51)]
    void ObjectEventClear(int ind, int evtype, int evnumb);

    [Gml("room_set_width", v51)]
    void RoomSetWidth(int ind, int w);

    [Gml("room_set_height", v51)]
    void RoomSetHeight(int ind, int h);

    [Gml("room_set_caption", v51)]
    void RoomSetCaption(int ind, string str);

    [Gml("room_set_persistent", v51)]
    void RoomSetPersistent(int ind, bool val);

    [Gml("room_set_code", v51)]
    void RoomSetCode(int ind, string str);

    [Gml("room_set_background_color", v51)]
    void RoomSetBackgroundColor(int ind, int col, bool show);

    [Gml("room_set_background", v51)]
    void RoomSetBackground(int ind, int bind, bool vis, bool fore, bool back, double x, double y, bool htiled, bool vtiled, double hspeed, double vspeed, int alpha);

    [Gml("room_set_view", v51)]
    void RoomSetView(int ind, int vind, bool vis, double left, double top, double width, double height, double x, double y, double hborder, double vborder, double hspeed, double vspeed, int obj);

    [Gml("room_set_view_enabled", v51)]
    void RoomSetViewEnabled(int ind, bool val);

    [Gml("room_add", v51)]
    int RoomAdd();

    [Gml("room_duplicate", v51)]
    int RoomDuplicate(int ind);

    [Gml("room_instance_add", v51)]
    int RoomInstanceAdd(int ind, double x, double y, int obj);

    [Gml("room_tile_add", v51)]
    int RoomTileAdd(int ind, int back, double left, double top, double width, double height, double x, double y, double depth);

    [Gml("room_tile_add_ext", v51)]
    int RoomTileAddExt(int ind, int back, double left, double top, double width, double height, double x, double y, double depth, double xscale, double yscale, int alpha);

    [Gml("room_tile_clear", v51)]
    void RoomTileClear(int ind);

    [Gml("ini_open", v51)]
    void IniOpen(string name);

    [Gml("ini_close", v51)]
    void IniClose();

    [Gml("ini_read_string", v51)]
    string IniReadString(string section, string key, string @default);

    [Gml("ini_read_real", v51)]
    double IniReadReal(string section, string key, double @default);

    [Gml("ini_write_string", v51)]
    void IniWriteString(string section, string key, string value);

    [Gml("ini_write_real", v51)]
    void IniWriteReal(string section, string key, double value);

    [Gml("ini_key_exists", v51)]
    bool IniKeyExists(string section, string key);

    [Gml("ini_section_exists", v51)]
    bool IniSectionExists(string section);

    [Gml("ini_key_delete", v51)]
    void IniKeyDelete(string section, string key);

    [Gml("ini_section_delete", v51)]
    void IniSectionDelete(string section);

    [Gml("part_type_create", v51)]
    int PartTypeCreate();

    [Gml("part_type_destroy", v51)]
    void PartTypeDestroy(int ind);

    [Gml("part_type_destroy_all", v51)]
    void PartTypeDestroyAll();

    [Gml("part_type_exists", v51)]
    bool PartTypeExists(int ind);

    [Gml("part_type_clear", v51)]
    void PartTypeClear(int ind);

    [Gml("part_type_shape", v51)]
    void PartTypeShape(int ind, int shape);

    [Gml("part_type_sprite", v51)]
    void PartTypeSprite(int ind, int sprite, bool animat, bool stretch, bool random);

    [Gml("part_type_size", v51)]
    void PartTypeSize(int ind, double size_min, double size_max, double size_incr, double size_rand);

    [Gml("part_type_color2", v51)]
    void PartTypeColor2(int ind, int color_start, int color_end);

    [Gml("part_type_life", v51)]
    void PartTypeLife(int ind, double life_min, double life_max);

    [Gml("part_type_speed", v51)]
    void PartTypeSpeed(int ind, double speed_min, double speed_max, double speed_incr, double speed_rand);

    [Gml("part_type_direction", v51)]
    void PartTypeDirection(int ind, double dir_min, double dir_max, double dir_incr, double dir_rand);

    [Gml("part_type_gravity", v51)]
    void PartTypeGravity(int ind, double grav_amount, double grav_dir);

    [Gml("part_type_step", v51)]
    void PartTypeStep(int ind, int step_number, int step_type);

    [Gml("part_type_death", v51)]
    void PartTypeDeath(int ind, int death_number, int death_type);

    [Gml("part_system_create", v51)]
    int PartSystemCreate();

    [Gml("part_system_destroy", v51)]
    void PartSystemDestroy(int ind);

    [Gml("part_system_destroy_all", v51)]
    void PartSystemDestroyAll();

    [Gml("part_system_exists", v51)]
    bool PartSystemExists(int ind);

    [Gml("part_system_clear", v51)]
    void PartSystemClear(int ind);

    [Gml("part_system_sprite_based", v51)]
    void PartSystemSpriteBased(int ind, bool set);

    [Gml("part_system_draw_order", v51)]
    void PartSystemDrawOrder(int ind, bool oldtonew);

    [Gml("part_particles_create", v51)]
    void PartParticlesCreate(int ind, double x, double y, int parttype, int number);

    [Gml("part_particles_clear", v51)]
    void PartParticlesClear(int ind);

    [Gml("part_particles_count", v51)]
    int PartParticlesCount(int ind);

    [Gml("part_emitter_create", v51)]
    int PartEmitterCreate(int ps);

    [Gml("part_emitter_destroy", v51)]
    void PartEmitterDestroy(int ps, int ind);

    [Gml("part_emitter_destroy_all", v51)]
    void PartEmitterDestroyAll(int ps);

    [Gml("part_emitter_exists", v51)]
    bool PartEmitterExists(int ps, int ind);

    [Gml("part_emitter_clear", v51)]
    void PartEmitterClear(int ps, int ind);

    [Gml("part_emitter_region", v51)]
    void PartEmitterRegion(int ps, int ind, double xmin, double xmax, double ymin, double ymax, int shape, int distribution);

    [Gml("part_emitter_burst", v51)]
    void PartEmitterBurst(int ps, int ind, int parttype, int number);

    [Gml("part_emitter_stream", v51)]
    void PartEmitterStream(int ps, int ind, int parttype, int number);

    [Gml("part_attractor_create", v51)]
    int PartAttractorCreate(int ps);

    [Gml("part_attractor_destroy", v51)]
    void PartAttractorDestroy(int ps, int ind);

    [Gml("part_attractor_destroy_all", v51)]
    void PartAttractorDestroyAll(int ps);

    [Gml("part_attractor_exists", v51)]
    bool PartAttractorExists(int ps, int ind);

    [Gml("part_attractor_clear", v51)]
    void PartAttractorClear(int ps, int ind);

    [Gml("part_attractor_position", v51)]
    void PartAttractorPosition(int ps, int ind, double x, double y);

    [Gml("part_attractor_force", v51)]
    void PartAttractorForce(int ps, int ind, double force, double dist, int kind, bool additive);

    [Gml("part_destroyer_create", v51)]
    int PartDestroyerCreate(int ps);

    [Gml("part_destroyer_destroy", v51)]
    void PartDestroyerDestroy(int ps, int ind);

    [Gml("part_destroyer_destroy_all", v51)]
    void PartDestroyerDestroyAll(int ps);

    [Gml("part_destroyer_exists", v51)]
    bool PartDestroyerExists(int ps, int ind);

    [Gml("part_destroyer_clear", v51)]
    void PartDestroyerClear(int ps, int ind);

    [Gml("part_destroyer_region", v51)]
    void PartDestroyerRegion(int ps, int ind, double xmin, double xmax, double ymin, double ymax, int shape);

    [Gml("part_deflector_create", v51)]
    int PartDeflectorCreate(int ps);

    [Gml("part_deflector_destroy", v51)]
    void PartDeflectorDestroy(int ps, int ind);

    [Gml("part_deflector_destroy_all", v51)]
    void PartDeflectorDestroyAll(int ps);

    [Gml("part_deflector_exists", v51)]
    bool PartDeflectorExists(int ps, int ind);

    [Gml("part_deflector_clear", v51)]
    void PartDeflectorClear(int ps, int ind);

    [Gml("part_deflector_region", v51)]
    void PartDeflectorRegion(int ps, int ind, double xmin, double xmax, double ymin, double ymax);

    [Gml("part_deflector_kind", v51)]
    void PartDeflectorKind(int ps, int kind);

    [Gml("part_deflector_friction", v51)]
    void PartDeflectorFriction(int ps, int kind);

    [Gml("part_changer_create", v51)]
    int PartChangerCreate(int ps);

    [Gml("part_changer_destroy", v51)]
    void PartChangerDestroy(int ps, int ind);

    [Gml("part_changer_destroy_all", v51)]
    void PartChangerDestroyAll(int ps);

    [Gml("part_changer_exists", v51)]
    bool PartChangerExists(int ps, int ind);

    [Gml("part_changer_clear", v51)]
    void PartChangerClear(int ps, int ind);

    [Gml("part_changer_region", v51)]
    void PartChangerRegion(int ps, int ind, double xmin, double xmax, double ymin, double ymax, int shape);

    [Gml("part_changer_types", v51)]
    void PartChangerTypes(int ps, int parttype1, int parttype2);

    [Gml("part_changer_kind", v51)]
    void PartChangerKind(int ps, int kind);
}
