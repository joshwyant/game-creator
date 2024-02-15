using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ID3dModelFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 6.1
    //
    [Gml("d3d_model_floor", v61)]
    void D3dModelFloor(int ind, double x1, double y1, double z1, double x2, double y2, double z2, double hrepeat, double vrepeat);

    [Gml("d3d_model_wall", v61)]
    void D3dModelWall(int ind, double x1, double y1, double z1, double x2, double y2, double z2, double hrepeat, double vrepeat);

    [Gml("d3d_model_ellipsoid", v61)]
    void D3dModelEllipsoid(int ind, double x1, double y1, double z1, double x2, double y2, double z2, double hrepeat, double vrepeat, double steps);

    [Gml("d3d_model_cone", v61)]
    void D3dModelCone(int ind, double x1, double y1, double z1, double x2, double y2, double z2, double hrepeat, double vrepeat, bool closed, double steps);

    [Gml("d3d_model_cylinder", v61)]
    void D3dModelCylinder(int ind, double x1, double y1, double z1, double x2, double y2, double z2, double hrepeat, double vrepeat, bool closed, double steps);

    [Gml("d3d_model_block", v61)]
    void D3dModelBlock(int ind, double x1, double y1, double z1, double x2, double y2, double z2, double hrepeat, double vrepeat);

    [Gml("d3d_model_primitive_end", v61)]
    void D3dModelPrimitiveEnd(int ind);

    [Gml("d3d_model_vertex_normal_texture_color", v61)]
    void D3dModelVertexNormalTextureColor(int ind, double x, double y, double z, double nx, double ny, double nz, double xtex, double ytex, double col, double alpha);

    [Gml("d3d_model_vertex_normal_texture", v61)]
    void D3dModelVertexNormalTexture(int ind, double x, double y, double z, double nx, double ny, double nz, double xtex, double ytex);

    [Gml("d3d_model_vertex_normal_color", v61)]
    void D3dModelVertexNormalColor(int ind, double x, double y, double z, double nx, double ny, double nz, double col, double alpha);

    [Gml("d3d_model_vertex_normal", v61)]
    void D3dModelVertexNormal(int ind, double x, double y, double z, double nx, double ny, double nz);

    [Gml("d3d_model_vertex_texture_color", v61)]
    void D3dModelVertexTextureColor(int ind, double x, double y, double z, double xtex, double ytex, double col, double alpha);

    [Gml("d3d_model_vertex_texture", v61)]
    void D3dModelVertexTexture(int ind, double x, double y, double z, double xtex, double ytex);

    [Gml("d3d_model_vertex_color", v61)]
    void D3dModelVertexColor(int ind, double x, double y, double z, double col, double alpha);

    [Gml("d3d_model_vertex", v61)]
    void D3dModelVertex(int ind, double x, double y, double z);

    [Gml("d3d_model_primitive_begin", v61)]
    void D3dModelPrimitiveBegin(int ind, int kind);

    [Gml("d3d_model_draw", v61)]
    void D3dModelDraw(int ind, double x, double y, double z, int texid);

    [Gml("d3d_model_load", v61)]
    void D3dModelLoad(int ind, string fname);

    [Gml("d3d_model_save", v61)]
    void D3dModelSave(int ind, string fname);

    [Gml("d3d_model_clear", v61)]
    void D3dModelClear(int ind);

    [Gml("d3d_model_destroy", v61)]
    void D3dModelDestroy(int ind);

    [Gml("d3d_model_create", v61)]
    void D3dModelCreate();
}
