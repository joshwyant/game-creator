using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDynamicFontFunctions
{
    #region Deprecated Functions
    #endregion
    
    //
    // 6.0
    //

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
}
