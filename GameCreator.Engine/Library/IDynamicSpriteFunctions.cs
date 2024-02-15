using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDynamicSpriteFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v4.1
    //
    [Gml("sprite_add", v41, v70)]
    int SpriteAdd(string fname, int imgnumb, bool precise, bool transparent, bool videomem, bool loadonuse, int xorig, int yorig);

    [Gml("sprite_replace", v41, v70)]
    void SpriteReplace(int ind, string fname, int imgnumb, bool precise, bool transparent, bool videomem, bool loadonuse, int xorig, int yorig);
    #endregion

    //
    // Introduced in v4.1
    //

    [Gml("sprite_delete", v41)]
    void SpriteDelete(int ind);
}
