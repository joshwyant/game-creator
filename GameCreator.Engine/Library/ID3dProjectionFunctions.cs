using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ID3dProjectionFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 6.0
    //
    [Gml("d3d_set_projection_ortho", v60)]
    void D3dSetProjectionOrtho(double x, double y, double w, double h, double angle);

    [Gml("d3d_set_projection_ext", v60)]
    void D3dSetProjectionExt(double xfrom, double yfrom, double zfrom, double xto, double yto, double zto, double xup, double yup, double zup, double angle, double aspeect, double znear, double zfar);

    [Gml("d3d_set_projection", v60)]
    void D3dSetProjection(double xfrom, double yfrom, double zfrom, double xto, double yto, double zto, double xup, double yup, double zup);
}
