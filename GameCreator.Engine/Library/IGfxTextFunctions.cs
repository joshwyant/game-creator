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

}
