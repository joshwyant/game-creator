using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ID3dFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 6.0
    //
    [Gml("d3d_set_depth", v60)]
    void D3dSetDepth(double depth);

    [Gml("d3d_set_perspective", v60)]
    void D3dSetPerspective(bool enable);

    [Gml("d3d_set_hidden", v60)]
    void D3dSetHidden(bool enable);

    [Gml("d3d_end", v60)]
    void D3dEnd();

    [Gml("d3d_start", v60)]
    void D3dStart();
}
