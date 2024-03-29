using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IGfxTextFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v1.4
    //
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

    //
    // Introduced in v2.0
    //
    [Gml("set_font_angle", v20, v33)]
    void SetFontAngle(int angle);
    #endregion

    //
    // Introduced in v2.0
    //

    [Gml("string_width", v20)]
    double StringWidth(string text);

    [Gml("string_height", v20)]
    double StringHeight(string text);

    //
    // Introduced in v4.3c
    //
    [Gml("draw_text_ext", v43c)]
    void DrawTextExt(int x, int y, string str, int sep, int w);

    [Gml("string_width_ext", v43c)]
    int StringWidthExt(string str, int sep, int w);

    [Gml("string_height_ext", v43c)]
    int StringHeightExt(string str, int sep, int w);

    //
    // Introduced in v5.0
    //
    [Gml("draw_text_sprite", v50)]
    void DrawTextSprite(double x, double y, string @string, int sep, double w, int sprite, int firstchar, double scale);

    //
    // Introduced in v6.0
    //
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
}
