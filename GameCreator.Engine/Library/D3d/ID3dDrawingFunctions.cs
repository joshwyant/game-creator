using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ID3dDrawingFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 6.0
    //
    [Gml("d3d_vertex_normal_texture_color", v60)]
    void D3dVertexNormalTextureColor(double x, double y, double z, double nx, double ny, double nz, double xtex, double ytex, int col, double alpha);

    [Gml("d3d_vertex_normal_texture", v60)]
    void D3dVertexNormalTexture(double x, double y, double z, double nx, double ny, double nz, double xtex, double ytex);

    [Gml("d3d_vertex_normal_color", v60)]
    void D3dVertexNormalColor(double x, double y, double z, double nx, double ny, double nz, int col, double alpha);

    [Gml("d3d_vertex_normal", v60)]
    void D3dVertexNormal(double x, double y, double z, double nx, double ny, double nz);

    [Gml("3d_draw_floor", v60)]
    void D3dDrawFloor(double x1, double y1, double z1, double x2, double y2, double z2, int texid, int hrepeat, int vrepeat);

    [Gml("3d_draw_wall", v60)]
    void D3dDrawWall(double x1, double y1, double z1, double x2, double y2, double z2, int texid, int hrepeat, int vrepeat);

    [Gml("d3d_draw_ellipsoid", v60)]
    void D3dDrawEllipsoid(double x1, double y1, double z1, double x2, double y2, double z2, int texid, int hrepeat, int vrepeat, int steps);

    [Gml("d3d_draw_cylinder", v60)]
    void D3dDrawCylinder(double x1, double y1, double z1, double x2, double y2, double z2, int texid, int hrepeat, int vrepeat, bool closed, int steps);

    [Gml("d3d_draw_block", v60)]
    void D3dDrawBlock(double x1, double y1, double z1, double x2, double y2, double z2, int texid, int hrepeat, int vrepeat);

    [Gml("d3d_set_culling", v60)]
    void D3dSetCulling(bool cull);

    [Gml("d3d_primitive_end", v60)]
    void D3dPrimitiveEnd();

    [Gml("d3d_vertex_texture_color", v60)]
    void D3dVertexTextureColor(double x, double y, double z, double xtex, double ytex, int col, double alpha);

    [Gml("d3d_vertex_texture", v60)]
    void D3dVertexTexture(double x, double y, double z, double xtex, double ytex);

    [Gml("d3d_primitive_begin_texture", v60)]
    void D3dPrimitiveBeginTexture(int kind, int texid);

    [Gml("d3d_vertex_color", v60)]
    void D3dVertexColor(double x, double y, double z, int col, double alpha);

    [Gml("d3d_vertex", v60)]
    void D3dVertex(double x, double y, double z);

    [Gml("d3d_primitive_begin", v60)]
    void D3dPrimitiveBegin(int kind);
}
