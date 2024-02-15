using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IResSpriteFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v4.3c
    //
    [Gml("sprite_get_videomem", v43c, v53a)]
    void SpriteGetVideomem(int ind);
    
    [Gml("sprite_get_loadonuse", v43c, v53a)]
    void SpriteGetLoadonuse(int ind);

    [Gml("sprite_get_transparent", v43c, v70)]
    bool SpriteGetTransparent(int ind);

    [Gml("sprite_get_precise", v43c, v70)]
    bool SpriteGetPrecise(int ind);
    #endregion

    //
    // Introduced in v4.0
    //
    [Gml("sprite_discard", v40)]
    void SpriteDiscard(double numb);

    [Gml("sprite_restore", v40)]
    void SpriteRestore(double numb);

    [Gml("discard_all", v40)]
    void DiscardAll();

    //
    // Introduced in v4.3
    //
    [Gml("sprite_exists", v43c)]
    bool SpriteExists(int ind);

    [Gml("sprite_get_name", v43c)]
    string SpriteGetName(int ind);

    [Gml("sprite_get_number", v43c)]
    int SpriteGetNumber(int ind);

    [Gml("sprite_get_width", v43c)]
    int SpriteGetWidth(int ind);

    [Gml("sprite_get_height", v43c)]
    int SpriteGetHeight(int ind);

    [Gml("sprite_get_xoffset", v43c)]
    int SpriteGetXoffset(int ind);

    [Gml("sprite_get_yoffset", v43c)]
    int SpriteGetYoffset(int ind);

    [Gml("sprite_get_bbox_left", v43c)]
    int SpriteGetBboxLeft(int ind);

    [Gml("sprite_get_bbox_right", v43c)]
    int SpriteGetBboxRight(int ind);

    [Gml("sprite_get_bbox_top", v43c)]
    int SpriteGetBboxTop(int ind);

    [Gml("sprite_get_bbox_bottom", v43c)]
    int SpriteGetBboxBottom(int ind);
}
