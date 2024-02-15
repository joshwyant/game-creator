using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IGfxScreenFunctions
{
    #region Deprecated Functions
    [Gml("redraw", v11, v33)]
    void Redraw();
    #endregion

}
