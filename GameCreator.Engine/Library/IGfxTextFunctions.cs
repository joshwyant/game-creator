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
    #endregion

}
