using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IGfxDrawShapesFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v1.4
    //
    [Gml("set_brush_color", v14, v33)]
    void SetBrushColor(int col);

    [Gml("set_pen_color", v14, v33)]
    void SetPenColor(int col);

    [Gml("draw_ellipse", v14, v53a)]
    void DrawEllipse(double x1, double y1, double x2, double y2);

    [Gml("draw_rectangle", v14, v53a)]
    void DrawRectangle(double x1, double y1, double x2, double y2);

    [Gml("draw_roundrect", v14, v53a)]
    void DrawRoundrect(double x1, double y1, double x2, double y2);

    [Gml("draw_triangle", v14, v53a)]
    void DrawTriangle(double x1, double y1, double x2, double y2, double x3, double y3);

    //
    // Introduced in v2.0
    //

    [Gml("draw_button", v20, v33)]
    void DrawButton(double x1, double y1, double x2, double y2, bool down);

    [Gml("set_brush_style", v20, v33)]
    void SetBrushStyle(int style);

    [Gml("set_pen_size", v20, v33)]
    void SetPenSize(int size);
    
    [Gml("draw_circle", v20, v53a)]
    void DrawCircle(double xc, double yc, double r);

    //
    // Introduced in v4.0
    //

    [Gml("draw_pixel", v40, v53a)]
    void DrawPixel(double x, double y);

    [Gml("draw_fill", v40, v53a)]
    void DrawFill(double x, double y);

    [Gml("draw_arc", v40, v53a)]
    void DrawArc(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4);

    [Gml("draw_chord", v40, v53a)]
    void DrawChord(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4);

    [Gml("draw_pie", v40, v53a)]
    void DrawPie(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4);

    [Gml("screen_gamma", v40, v53a)]
    void ScreenGamma(int r, int g, int b);
    #endregion

    //
    // Introduced in v1.4
    //
    [Gml("draw_line", v14)]
    void DrawLine(double x1, double y1, double x2, double y2);

    [Gml("draw_text", v14)]
    void DrawText(double x, double y, string str);

    //
    // Introduced in v4.0
    //
    [Gml("draw_button", v40)]
    void DrawButton(double x1, double y1, double x2, double y2, double up);
    
    [Gml("make_color", v40)]
    double MakeColor(double red, double green, double blue);

    //
    // Introduced in v4.1
    //
    [Gml("draw_getpixel", v41)]
    int DrawGetpixel(int x, int y);

    //
    // Introduced in v4.2a
    //
    [Gml("draw_polygon_begin", v42a)]
    void DrawPolygonBegin();

    [Gml("draw_polygon_vertex", v42a)]
    void DrawPolygonVertex(double x, double y);

    [Gml("draw_polygon_end", v42a)]
    void DrawPolygonEnd();

    //
    // Introduced in v5.1
    //
    [Gml("push_graphics_settings", v51)]
    void PushGraphicsSettings();

    [Gml("pop_graphics_settings", v51)]
    void PopGraphicsSettings();
    
    [Gml("draw_arrow", v51)]
    void DrawArrow(double x1, double y1, double x2, double y2, double size);

    //
    // 5.3a
    //
    [Gml("draw_path", v53a)]
    double DrawPath(double path, double x, double y, double absolute);

    [Gml("draw_healthbar", v53a)]
    double DrawHealthbar(double x1, double y1, double x2, double y2, double amount, double backcol, double mincol, double maxcol, double direction, double showback, double showborder);

    [Gml("make_color_rgb", v53a)]
    double MakeColorRgb(double red, double green, double blue);

    [Gml("make_color_hsv", v53a)]
    double MakeColorHsv(double hue, double saturation, double value);

    [Gml("color_get_red", v53a)]
    double ColorGetRed(double col);

    [Gml("color_get_green", v53a)]
    double ColorGetGreen(double col);

    [Gml("color_get_blue", v53a)]
    double ColorGetBlue(double col);

    [Gml("color_get_hue", v53a)]
    double ColorGetHue(double col);

    [Gml("color_get_saturation", v53a)]
    double ColorGetSaturation(double col);

    [Gml("color_get_value", v53a)]
    double ColorGetValue(double col);

    [Gml("merge_color", v53a)]
    double MergeColor(double col1, double col2, double amount);

    //
    // 6.0
    //
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

    //
    // 7.0
    //
    [Gml("draw_set_circle_precision", v70)]
    void DrawSetCirclePrecision(double precision);
    
    [Gml("draw_line_width_color", v70)]
    void DrawLineWidthColor(double x1, double y1, double x2, double y2, double w, int col1, int col2);

    [Gml("draw_line_width", v70)]
    void DrawLineWidth(double x1, double y1, double x2, double y2, double w);
}
