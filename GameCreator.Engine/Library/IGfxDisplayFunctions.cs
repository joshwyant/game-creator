using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IGfxDisplayFunctions
{
    #region Deprecated Functions
    [Gml("set_graphics_mode", v51, v53a)]
    void SetGraphicsMode(bool exclusive, int horres, int coldepth, int freq, bool fullscreen, int winscale, int fullscale);
    #endregion

}
