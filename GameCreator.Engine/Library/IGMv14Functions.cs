using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
chr(val)	1.4
ord(val)	1.4
string(x)	1.4
show_info()	1.4
show_message(str)	1.4
show_question(str)	1.4
get_integer(str, def)	1.4
get_string(str, def)	1.4
draw_line(x1, y1, x2, y2)	1.4
draw_text(x, y, str)	1.4

*/

public interface IGMv14Functions
{
    [Gml("check_key", v14, v33)]
    bool CheckKey(int keycode);

    [Gml("draw_image", v14, v33)]
    void DrawImage(double x, double y, int obj);

    [Gml("draw_subimage", v14, v33)]
    void DrawSubimage(double x, double y, int obj, int ind);

    [Gml("set_brush_color", v14, v33)]
    void SetBrushColor(int col);

    [Gml("set_pen_color", v14, v33)]
    void SetPenColor(int col);

    [Gml("set_font_color", v14, v33)]
    void SetFontColor(int col);

    [Gml("set_font_size", v14, v33)]
    void SetFontSize(int size);

    [Gml("set_font_style", v14, v33)]
    void SetFontStyle(int style);

    [Gml("set_font_align", v14, v33)]
    void SetFontAlign(int align);

    [Gml("set_font_name", v14, v33)]
    void SetFontName(string name);

    [Gml("draw_ellipse", v14, v53a)]
    void DrawEllipse(double x1, double y1, double x2, double y2);

    [Gml("draw_rectangle", v14, v53a)]
    void DrawRectangle(double x1, double y1, double x2, double y2);

    [Gml("draw_roundrect", v14, v53a)]
    void DrawRoundrect(double x1, double y1, double x2, double y2);

    [Gml("draw_triangle", v14, v53a)]
    void DrawTriangle(double x1, double y1, double x2, double y2, double x3, double y3);
    [Gml("chr", v14)]
    string Chr(double val);

    [Gml("ord", v14)]
    double Ord(string val);

    [Gml("string", v14)]
    string String(double x);

    [Gml("show_info", v14)]
    void ShowInfo();

    [Gml("show_message", v14)]
    void ShowMessage(string str);

    [Gml("show_question", v14)]
    void ShowQuestion(string str);

    [Gml("get_integer", v14)]
    double GetInteger(string str, double def);

    [Gml("get_string", v14)]
    string GetString(string str, string def);

    [Gml("draw_line", v14)]
    void DrawLine(double x1, double y1, double x2, double y2);

    [Gml("draw_text", v14)]
    void DrawText(double x, double y, string str);
}