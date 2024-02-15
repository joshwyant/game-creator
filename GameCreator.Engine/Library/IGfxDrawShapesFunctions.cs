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
}
