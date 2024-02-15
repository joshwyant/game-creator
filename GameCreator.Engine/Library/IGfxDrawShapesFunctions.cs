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

    [Gml("draw_button", v20, v33)]
    void DrawButton(double x1, double y1, double x2, double y2, bool down);

    [Gml("set_brush_style", v20, v33)]
    void SetBrushStyle(int style);

    [Gml("set_pen_size", v20, v33)]
    void SetPenSize(int size);
    
    [Gml("draw_circle", v20, v53a)]
    void DrawCircle(double xc, double yc, double r);
    #endregion

    //
    // Introduced in v1.4
    //
    [Gml("draw_line", v14)]
    void DrawLine(double x1, double y1, double x2, double y2);

    [Gml("draw_text", v14)]
    void DrawText(double x, double y, string str);
}
