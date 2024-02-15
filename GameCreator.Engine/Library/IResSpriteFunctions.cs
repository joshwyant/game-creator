using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IResSpriteFunctions
{
    #region Deprecated Functions
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
}
