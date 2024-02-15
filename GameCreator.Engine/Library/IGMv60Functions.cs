using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
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
d3d_transform_stack_push()	6.0	
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

Deprecated functions:
background_get_preload(ind)	6.0	7.0
background_get_smooth(ind)	6.0	7.0
sprite_get_preload(ind)	6.0	7.0
sprite_get_smooth(ind)	6.0	7.0

*/

public interface IGMv60Functions
{
    #region Functions
    [Gml("move_wrap", v60)]
    void MoveWrap(bool hor, bool vert, double margin);

    [Gml("keyboard_check_pressed", v60)]
    bool KeyboardCheckPressed(int key);

    [Gml("keyboard_check_released", v60)]
    bool KeyboardCheckReleased(int key);

    [Gml("mouse_check_button_pressed", v60)]
    bool MouseCheckButtonPressed(int numb);

    [Gml("mouse_check_button_released", v60)]
    bool MouseCheckButtonReleased(int numb);

    [Gml("draw_sprite_general", v60)]
    void DrawSpriteGeneral(int sprite, int subimg, double left, double top, double right, double bottom, double x, double y, double xscale, double yscale, double rot, int c1, int c2, int c3, int c4, double alpha);

    [Gml("draw_background_general", v60)]
    void DrawBackgroundGeneral(int back, double left, double top, double right, double bottom, double x, double y, double xscale, double yscale, double rot, int c1, int c2, int c3, int c4, double alpha);

    [Gml("draw_clear", v60)]
    void DrawClear(int col);

    [Gml("draw_rectangle", v60)]
    void DrawRectangle(double x1, double y1, double x2, double y2, bool outline);

    [Gml("draw_roundrect", v60)]
    void DrawRoundrect(double x1, double y1, double x2, double y2, bool outline);

    [Gml("draw_triangle", v60)]
    void DrawTriangle(double x1, double y1, double x2, double y2, double x3, double y3, bool outline);

    [Gml("draw_circle", v60)]
    void DrawCircle(double x, double y, double r, bool outline);

    [Gml("draw_ellipse", v60)]
    void DrawEllipse(double x1, double y1, double x2, double y2, bool outline);

    [Gml("draw_set_color", v60)]
    void DrawSetColor(int col);

    [Gml("draw_set_alpha", v60)]
    void DrawSetAlpha(double alpha);

    [Gml("draw_get_color", v60)]
    int DrawGetColor();

    [Gml("draw_get_alpha", v60)]
    double DrawGetAlpha();

    [Gml("draw_set_font", v60)]
    void DrawSetFont(int font);

    [Gml("draw_set_halign", v60)]
    void DrawSetHalign(int halign);

    [Gml("draw_set_valign", v60)]
    void DrawSetValign(int valign);

    [Gml("draw_text_transformed", v60)]
    void DrawTextTransformed(double x, double y, string @string, double xscale, double yscale, double angle);

    [Gml("draw_text_ext_transformed", v60)]
    void DrawTextExtTransformed(double x, double y, string @string, double sep, double w, double xscale, double yscale, double angle);

    [Gml("draw_text_color", v60)]
    void DrawTextColor(double x, double y, string @string, int c1, int c2, int c3, int c4, double alpha);

    [Gml("draw_text_ext_color", v60)]
    void DrawTextExtColor(double x, double y, string @string, double sep, double w, int c1, int c2, int c3, int c4, double alpha);

    [Gml("draw_text_transformed_color", v60)]
    void DrawTextTransformedColor(double x, double y, string @string, double sep, double w, int c1, int c2, int c3, int c4, double alpha);

    [Gml("draw_text_ext_transformed_color", v60)]
    void DrawTextExtTransformedColor(double x, double y, string @string, double sep, double w, double xscale, double yscale, double angle, int c1, int c2, int c3, int c4, double alpha);

    [Gml("draw_point_color", v60)]
    void DrawPointColor(double x, double y, int col1);

    [Gml("draw_line_color", v60)]
    void DrawLineColor(double x1, double y1, double x2, double y2, int col1, int col2);

    [Gml("draw_rectangle_color", v60)]
    void DrawRectangleColor(double x1, double y1, double x2, double y2, int col1, int col2, int col3, int col4, bool outline);

    [Gml("draw_roundrect_color", v60)]
    void DrawRoundrectColor(double x1, double y1, double x2, double y2, int col1, int col2, bool outline);

    [Gml("draw_triangle_color", v60)]
    void DrawTriangleColor(double x1, double y1, double x2, double y2, double x3, double y3, int col1, int col2, int col3, bool outline);

    [Gml("draw_circle_color", v60)]
    void DrawCircleColor(double x, double y, double r, int col1, int col2, bool outline);

    [Gml("draw_ellipse_color", v60)]
    void DrawEllipseColor(double x1, double y1, double x2, double y2, int col1, int col2, bool outline);

    [Gml("draw_primitive_begin", v60)]
    void DrawPrimitiveBegin(int kind);

    [Gml("draw_vertex", v60)]
    void DrawVertex(double x, double y);

    [Gml("draw_vertex_color", v60)]
    void DrawVertexColor(double x, double y, int col, double alpha);

    [Gml("draw_primitive_end", v60)]
    void DrawPrimitiveEnd();

    [Gml("sprite_get_texture", v60)]
    int SpriteGetTexture(int spr, int subimg);

    [Gml("background_get_texture", v60)]
    int BackgroundGetTexture(int back);

    [Gml("texture_preload", v60)]
    void TexturePreload(int texid);

    [Gml("texture_set_priority", v60)]
    void TextureSetPriority(int texid, int prio);

    [Gml("texture_get_width", v60)]
    int TextureGetWidth(int texid);

    [Gml("texture_get_height", v60)]
    int TextureGetHeight(int texid);

    [Gml("draw_primitive_begin_texture", v60)]
    void DrawPrimitiveBeginTexture(int kind, int texid);

    [Gml("draw_vertex_texture", v60)]
    void DrawVertexTexture(double x, double y, double xtex, double ytex);

    [Gml("draw_vertex_texture_color", v60)]
    void DrawVertexTextureColor(double x, double y, double xtex, double ytex, int col, double alpha);

    [Gml("texture_set_interpolation", v60)]
    void TextureSetInterpolation(bool linear);

    [Gml("texture_set_blending", v60)]
    void TextureSetBlending(bool blend);

    [Gml("texture_set_repeat", v60)]
    void TextureSetRepeat(bool repeat);

    [Gml("draw_set_blend_mode", v60)]
    void DrawSetBlendMode(int mode);

    [Gml("draw_set_blend_mode_ext", v60)]
    void DrawSetBlendModeExt(int src, int dest);

    [Gml("tile_get_blend", v60)]
    int TileGetBlend(int id);

    [Gml("tile_set_blend", v60)]
    void TileSetBlend(int id, int color);

    [Gml("display_get_width", v60)]
    int DisplayGetWidth();

    [Gml("display_get_height", v60)]
    int DisplayGetHeight();

    [Gml("display_get_colordepth", v60)]
    int DisplayGetColordepth();

    [Gml("display_mouse_set", v60)]
    void DisplayMouseSet(double x, double y);

    [Gml("display_mouse_get_y", v60)]
    double DisplayMouseGetY();

    [Gml("display_mouse_get_x", v60)]
    double DisplayMouseGetX();

    [Gml("display_reset", v60)]
    void DisplayReset();

    [Gml("display_test_all", v60)]
    bool DisplayTestAll(int w, int h, int frequency, int coldepth);

    [Gml("display_set_all", v60)]
    void DisplaySetAll(int w, int h, int frequency, int coldepth);

    [Gml("display_set_colordepth", v60)]
    void DisplaySetColordepth(int coldepth);

    [Gml("display_set_frequency", v60)]
    void DisplaySetFrequency(int frequency);

    [Gml("display_get_frequency", v60)]
    int DisplayGetFrequency();

    [Gml("display_set_size", v60)]
    void DisplaySetSize(int w, int h);

    [Gml("d3d_vertex_normal_texture_color", v60)]
    void D3dVertexNormalTextureColor(double x, double y, double z, double nx, double ny, double nz, double xtex, double ytex, int col, double alpha);

    [Gml("d3d_vertex_normal_texture", v60)]
    void D3dVertexNormalTexture(double x, double y, double z, double nx, double ny, double nz, double xtex, double ytex);

    [Gml("d3d_vertex_normal_color", v60)]
    void D3dVertexNormalColor(double x, double y, double z, double nx, double ny, double nz, int col, double alpha);

    [Gml("d3d_vertex_normal", v60)]
    void D3dVertexNormal(double x, double y, double z, double nx, double ny, double nz);

    [Gml("d3d_light_enable", v60)]
    void D3dLightEnable(int ind, bool enable);

    [Gml("d3d_light_define_point", v60)]
    void D3dLightDefinePoint(int ind, double x, double y, double z, double range, int col);

    [Gml("d3d_light_define_direction", v60)]
    void D3dLightDefineDirection(int ind, double dx, double dy, double dz, int col);

    [Gml("d3d_set_shading", v60)]
    void D3dSetShading(bool smooth);

    [Gml("d3d_set_lighting", v60)]
    void D3dSetLighting(bool enable);

    [Gml("d3d_set_fog", v60)]
    void D3dSetFog(bool enable, int color, double start, double end);

    [Gml("d3d_transform_stack_discard", v60)]
    void D3dTransformStackDiscard();

    [Gml("d3d_transform_stack_top", v60)]
    int D3dTransformStackTop();

    [Gml("d3d_transform_stack_pop", v60)]
    void D3dTransformStackPop();

    [Gml("d3d_transform_stack_push", v60)]
    void D3dTransformStackPush();

    [Gml("d3d_transform_stack_empty", v60)]
    bool D3dTransformStackEmpty();

    [Gml("d3d_transform_stack_clear", v60)]
    void D3dTransformStackClear();

    [Gml("d3d_transform_add_rotation_axis", v60)]
    void D3dTransformAddRotationAxis(double xa, double ya, double za, double angle);

    [Gml("d3d_transform_add_rotation_z", v60)]
    void D3dTransformAddRotationZ(double angle);

    [Gml("d3d_transform_add_rotation_y", v60)]
    void D3dTransformAddRotationY(double angle);

    [Gml("d3d_transform_add_rotation_x", v60)]
    void D3dTransformAddRotationX(double angle);

    [Gml("d3d_transform_add_scaling", v60)]
    void D3dTransformAddScaling(double xs, double ys, double zs);

    [Gml("d3d_transform_add_translation", v60)]
    void D3dTransformAddTranslation(double xs, double ys, double zs);

    [Gml("d3d_transform_set_rotation_axis", v60)]
    void D3dTransformSetRotationAxis(double xa, double ya, double za, double angle);

    [Gml("d3d_transform_set_rotation_z", v60)]
    void D3dTransformSetRotationZ(double angle);

    [Gml("d3d_transform_set_rotation_y", v60)]
    void D3dTransformSetRotationY(double angle);

    [Gml("d3d_transform_set_rotation_x", v60)]
    void D3dTransformSetRotationX(double angle);

    [Gml("d3d_transform_set_scaling", v60)]
    void D3dTransformSetScaling(double xs, double ys, double zs);

    [Gml("d3d_transform_set_translation", v60)]
    void D3dTransformSetTranslation(double xt, double yt, double zt);

    [Gml("d3d_transform_set_identity", v60)]
    void D3dTransformSetIdentity();

    [Gml("d3d_set_projection_ortho", v60)]
    void D3dSetProjectionOrtho(double x, double y, double w, double h, double angle);

    [Gml("d3d_set_projection_ext", v60)]
    void D3dSetProjectionExt(double xfrom, double yfrom, double zfrom, double xto, double yto, double zto, double xup, double yup, double zup, double angle, double aspeect, double znear, double zfar);

    [Gml("d3d_set_projection", v60)]
    void D3dSetProjection(double xfrom, double yfrom, double zfrom, double xto, double yto, double zto, double xup, double yup, double zup);

    [Gml("3d_draw_floor", v60)]
    void D3dDrawFloor(double x1, double y1, double z1, double x2, double y2, double z2, int texid, int hrepeat, int vrepeat);

    [Gml("3d_draw_wall", v60)]
    void D3dDrawWall(double x1, double y1, double z1, double x2, double y2, double z2, int texid, int hrepeat, int vrepeat);

    [Gml("d3d_draw_ellipsoid", v60)]
    void D3dDrawEllipsoid(double x1, double y1, double z1, double x2, double y2, double z2, int texid, int hrepeat, int vrepeat, int steps);

    [Gml("d3d_draw_cylinder", v60)]
    void D3dDrawCylinder(double x1, double y1, double z1, double x2, double y2, double z2, int texid, int hrepeat, int vrepeat, bool closed, int steps);

    [Gml("d3d_draw_block", v60)]
    void D3dDrawBlock(double x1, double y1, double z1, double x2, double y2, double z2, int texid, int hrepeat, int vrepeat);

    [Gml("d3d_set_culling", v60)]
    void D3dSetCulling(bool cull);

    [Gml("d3d_primitive_end", v60)]
    void D3dPrimitiveEnd();

    [Gml("d3d_vertex_texture_color", v60)]
    void D3dVertexTextureColor(double x, double y, double z, double xtex, double ytex, int col, double alpha);

    [Gml("d3d_vertex_texture", v60)]
    void D3dVertexTexture(double x, double y, double z, double xtex, double ytex);

    [Gml("d3d_primitive_begin_texture", v60)]
    void D3dPrimitiveBeginTexture(int kind, int texid);

    [Gml("d3d_vertex_color", v60)]
    void D3dVertexColor(double x, double y, double z, int col, double alpha);

    [Gml("d3d_vertex", v60)]
    void D3dVertex(double x, double y, double z);

    [Gml("d3d_primitive_begin", v60)]
    void D3dPrimitiveBegin(int kind);

    [Gml("d3d_set_depth", v60)]
    void D3dSetDepth(double depth);

    [Gml("d3d_set_perspective", v60)]
    void D3dSetPerspective(bool enable);

    [Gml("d3d_set_hidden", v60)]
    void D3dSetHidden(bool enable);

    [Gml("d3d_end", v60)]
    void D3dEnd();

    [Gml("d3d_start", v60)]
    void D3dStart();

    [Gml("part_type_alpha2", v60)]
    void PartTypeAlpha2(int ind, double alpha_start, double alpha_end);

    [Gml("part_type_alpha", v60)]
    void PartTypeAlpha(int ind, double alpha_start, double alpha_middle, double alpha_end);

    [Gml("room_assign", v60)]
    void RoomAssign(int ind, int room);

    [Gml("font_delete", v60)]
    void FontDelete(int ind);

    [Gml("font_replace_sprite", v60)]
    void FontReplaceSprite(int ind, int spr, int first, int prop, int sep);

    [Gml("font_replace", v60)]
    void FontReplace(int ind, string name, int size, bool bold, bool italic, int first, int last);

    [Gml("font_add_sprite", v60)]
    void FontAddSprite(int spr, int first, int prop, int sep);

    [Gml("font_add", v60)]
    void FontAdd(string name, int size, bool bold, bool italic, int first, int last);

    [Gml("background_create_gradient", v60)]
    void BackgroundCreateGradient(int w, int h, int col1, int col2, int kind, bool preload);

    [Gml("background_create_color", v60)]
    void BackgroundCreateColor(int w, int h, int color, bool preload);

    [Gml("background_assign", v60)]
    void BackgroundAssign(int ind, int back);

    [Gml("background_set_alpha_from_background", v60)]
    void BackgroundSetAlphaFromBackground(int ind, int back);

    [Gml("sprite_set_alpha_from_sprite", v60)]
    void SpriteSetAlphaFromSprite(int ind, int spr);

    [Gml("sound_get_preload", v60)]
    bool SoundGetPreload(int ind);

    [Gml("highscore_set_strings", v60)]
    void HighscoreSetStrings(string caption, string nobody, string escape);

    [Gml("highscore_set_colors", v60)]
    void HighscoreSetColors(int back, int newcol, int other);

    [Gml("highscore_set_font", v60)]
    void HighscoreSetFont(string name, int size, int style);

    [Gml("highscore_set_border", v60)]
    void HighscoreSetBorder(bool show);

    [Gml("highscore_set_background", v60)]
    void HighscoreSetBackground(int back);

    [Gml("sound_3d_set_sound_cone", v60)]
    void Sound3dSetSoundCone(int snd, double x, double y, double z, double anglein, double angleout, double voloutside);

    [Gml("sound_3d_set_sound_distance", v60)]
    void Sound3dSetSoundDistance(int snd, double mindist, double maxdist);

    [Gml("sound_3d_set_sound_velocity", v60)]
    void Sound3dSetSoundVelocity(int snd, double x, double y, double z);

    [Gml("sound_3d_set_sound_position", v60)]
    void Sound3dSetSoundPosition(int snd, double x, double y, double z);

    [Gml("sound_effect_equalizer", v60)]
    void SoundEffectEqualizer(int snd, double center, double bandwidth, double gain);

    [Gml("sound_effect_compressor", v60)]
    void SoundEffectCompressor(int snd, double gain, double attack, double release, double threshold, double ratio, double delay);

    [Gml("sound_effect_reverb", v60)]
    void SoundEffectReverb(int snd, double gain, double mix, double time, double ratio);

    [Gml("sound_effect_gargle", v60)]
    void SoundEffectGargle(int snd, int rate, int wave);

    [Gml("sound_effect_flanger", v60)]
    void SoundEffectFlanger(int snd, double wetdry, double depth, double feedback, double frequency, int wave, double delay, double phase);

    [Gml("sound_effect_echo", v60)]
    void SoundEffectEcho(int snd, double wetdry, double feedback, double leftdelay, double rightdelay, double pandelay);

    [Gml("sound_effect_chorus", v60)]
    void SoundEffectChorus(int snd, double wetdry, double depth, double feedback, double frequency, int wave, double delay, double phase);

    [Gml("sound_effect_set", v60)]
    void SoundEffectSet(int snd, int effect);

    [Gml("sound_set_search_directory", v60)]
    void SoundSetSearchDirectory(string dir);

    [Gml("sound_fade", v60)]
    void SoundFade(int index, double value, double time);

    [Gml("sound_background_tempo", v60)]
    void SoundBackgroundTempo(double factor);

    [Gml("sound_global_volume", v60)]
    void SoundGlobalVolume(double value);

    [Gml("set_synchronization", v60)]
    void SetSynchronization(bool value);

    [Gml("set_automatic_draw", v60)]
    void SetAutomaticDraw(bool value);

    [Gml("window_views_mouse_set", v60)]
    void WindowViewsMouseSet(double x, double y);

    [Gml("window_views_mouse_get_y", v60)]
    double WindowViewsMouseGetY();

    [Gml("window_views_mouse_get_x", v60)]
    double WindowViewsMouseGetX();

    [Gml("window_view_mouse_set", v60)]
    void WindowViewMouseSet(int id, double x, double y);

    [Gml("window_view_mouse_get_y", v60)]
    double WindowViewMouseGetY(int id);

    [Gml("window_view_mouse_get_x", v60)]
    double WindowViewMouseGetX(int id);

    [Gml("window_get_region_height", v60)]
    double WindowGetRegionHeight();

    [Gml("window_get_region_width", v60)]
    double WindowGetRegionWidth();

    [Gml("window_set_region_size", v60)]
    void WindowSetRegionSize(int w, int h, bool adaptwindow);

    [Gml("window_mouse_set", v60)]
    void WindowMouseSet(double x, double y);

    [Gml("window_mouse_get_y", v60)]
    double WindowMouseGetY();

    [Gml("window_mouse_get_x", v60)]
    double WindowMouseGetX();

    [Gml("window_get_height", v60)]
    double WindowGetHeight();

    [Gml("window_get_width", v60)]
    double WindowGetWidth();

    [Gml("window_get_y", v60)]
    double WindowGetY();

    [Gml("window_get_x", v60)]
    double WindowGetX();

    [Gml("window_default", v60)]
    void WindowDefault();

    [Gml("window_center", v60)]
    void WindowCenter();

    [Gml("window_set_rectangle", v60)]
    void WindowSetRectangle(double x, double y, double w, double h);

    [Gml("window_set_size", v60)]
    void WindowSetSize(double w, double h);

    [Gml("window_set_position", v60)]
    void WindowSetPosition(double x, double y);

    [Gml("window_get_region_scale", v60)]
    double WindowGetRegionScale();

    [Gml("window_set_region_scale", v60)]
    void WindowSetRegionScale(double scale, bool adaptwindow);

    [Gml("window_get_color", v60)]
    int WindowGetColor(int color);

    [Gml("window_set_color", v60)]
    void WindowSetColor(int color);

    [Gml("window_get_cursor", v60)]
    int WindowGetCursor();

    [Gml("window_set_cursor", v60)]
    void WindowSetCursor(int curs);

    [Gml("window_get_caption", v60)]
    string WindowGetCaption();

    [Gml("window_set_caption", v60)]
    void WindowSetCaption(string caption);

    [Gml("window_get_sizeable", v60)]
    bool WindowGetSizeable();

    [Gml("window_set_sizeable", v60)]
    void WindowSetSizeable(bool sizeable);

    [Gml("window_get_stayontop", v60)]
    bool WindowGetStayontop();

    [Gml("window_set_stayontop", v60)]
    void WindowSetStayontop(bool stay);

    [Gml("window_get_showicons", v60)]
    bool WindowGetShowicons();

    [Gml("window_set_showicons", v60)]
    void WindowSetShowicons(bool show);

    [Gml("window_get_showborder", v60)]
    bool WindowGetShowborder();

    [Gml("window_set_showborder", v60)]
    void WindowSetShowborder(bool show);

    [Gml("window_get_fullscreen", v60)]
    bool WindowGetFullscreen();

    [Gml("window_set_fullscreen", v60)]
    void WindowSetFullscreen(bool full);

    [Gml("window_get_visible", v60)]
    bool WindowGetVisible();

    [Gml("window_set_visible", v60)]
    void WindowSetVisible(bool visible);
    #endregion

    #region Deprecated functions
    [Gml("background_get_preload", v60)]
    bool BackgroundGetPreload(int ind);

    [Gml("background_get_smooth", v60)]
    bool BackgroundGetSmooth(int ind);

    [Gml("sprite_get_preload", v60)]
    bool SpriteGetPreload(int ind);

    [Gml("sprite_get_smooth", v60)]
    bool SpriteGetSmooth(int ind);
    #endregion
}