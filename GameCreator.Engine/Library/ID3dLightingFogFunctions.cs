using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ID3dLightingFogFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 6.0
    //
    [Gml("d3d_light_enable", v60)]
    void D3dLightEnable(int ind, bool enable);

    [Gml("d3d_light_define_point", v60)]
    void D3dLightDefinePoint(int ind, double x, double y, double z, double range, int col);

    [Gml("d3d_light_define_direction", v60)]
    void D3dLightDefineDirection(int ind, double dx, double dy, double dz, int col);

    [Gml("d3d_set_shading", v60)]
    void D3dSetShading(bool smooth);

    [Gml("d3d_set_lighting", v60)]
    void D3dSetLighting(bool enable);

    [Gml("d3d_set_fog", v60)]
    void D3dSetFog(bool enable, int color, double start, double end);
}
