using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ID3dTransformationFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 6.0
    //
    [Gml("d3d_transform_stack_discard", v60)]
    void D3dTransformStackDiscard();

    [Gml("d3d_transform_stack_top", v60)]
    int D3dTransformStackTop();

    [Gml("d3d_transform_stack_pop", v60)]
    void D3dTransformStackPop();

    [Gml("d3d_transform_stack_push", v60)]
    void D3dTransformStackPush();

    [Gml("d3d_transform_stack_empty", v60)]
    bool D3dTransformStackEmpty();

    [Gml("d3d_transform_stack_clear", v60)]
    void D3dTransformStackClear();

    [Gml("d3d_transform_add_rotation_axis", v60)]
    void D3dTransformAddRotationAxis(double xa, double ya, double za, double angle);

    [Gml("d3d_transform_add_rotation_z", v60)]
    void D3dTransformAddRotationZ(double angle);

    [Gml("d3d_transform_add_rotation_y", v60)]
    void D3dTransformAddRotationY(double angle);

    [Gml("d3d_transform_add_rotation_x", v60)]
    void D3dTransformAddRotationX(double angle);

    [Gml("d3d_transform_add_scaling", v60)]
    void D3dTransformAddScaling(double xs, double ys, double zs);

    [Gml("d3d_transform_add_translation", v60)]
    void D3dTransformAddTranslation(double xs, double ys, double zs);

    [Gml("d3d_transform_set_rotation_axis", v60)]
    void D3dTransformSetRotationAxis(double xa, double ya, double za, double angle);

    [Gml("d3d_transform_set_rotation_z", v60)]
    void D3dTransformSetRotationZ(double angle);

    [Gml("d3d_transform_set_rotation_y", v60)]
    void D3dTransformSetRotationY(double angle);

    [Gml("d3d_transform_set_rotation_x", v60)]
    void D3dTransformSetRotationX(double angle);

    [Gml("d3d_transform_set_scaling", v60)]
    void D3dTransformSetScaling(double xs, double ys, double zs);

    [Gml("d3d_transform_set_translation", v60)]
    void D3dTransformSetTranslation(double xt, double yt, double zt);

    [Gml("d3d_transform_set_identity", v60)]
    void D3dTransformSetIdentity();
}
