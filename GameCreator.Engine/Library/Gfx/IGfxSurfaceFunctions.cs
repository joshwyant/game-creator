using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IGfxSurfaceFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 6.1
    //
    [Gml("surface_copy_part", v61)]
    void SurfaceCopyPart(int destination, double x, double y, int source, double xs, double ys, double ws, double hs);

    [Gml("surface_copy", v61)]
    void SurfaceCopy(int destination, double x, double y, int source);

    [Gml("draw_surface_general", v61)]
    void DrawSurfaceGeneral(int id, double left, double top, double width, double height, double x, double y, double xscale, double yscale, double rot, double c1, double c2, double c3, double c4, double alpha);

    [Gml("draw_surface_part_ext", v61)]
    void DrawSurfacePartExt(int id, double left, double top, double width, double height, double x, double y, double xscale, double yscale, double color, double alpha);

    [Gml("draw_surface_tiled_ext", v61)]
    void DrawSurfaceTiledExt(int id, double x, double y, double xscale, double yscale, double color, double alpha);

    [Gml("draw_surface_stretched_ext", v61)]
    void DrawSurfaceStretchedExt(int id, double x, double y, double w, double h, double color, double alpha);

    [Gml("draw_surface_ext", v61)]
    void DrawSurfaceExt(int id, double x, double y, double xscale, double yscale, double rot, double color, double alpha);

    [Gml("draw_surface_part", v61)]
    void DrawSurfacePart(int id, double left, double top, double width, double height, double x, double y);

    [Gml("draw_surface_tiled", v61)]
    void DrawSurfaceTiled(int id, double x, double y);

    [Gml("draw_surface_stretched", v61)]
    void DrawSurfaceStretched(int id, double x, double y, double w, double h);

    [Gml("surface_save", v61)]
    void SurfaceSave(int id, string fname);

    [Gml("surface_getpixel", v61)]
    double SurfaceGetpixel(int id, double x, double y);

    [Gml("surface_reset_target", v61)]
    void SurfaceResetTarget(int id);

    [Gml("surface_set_target", v61)]
    void SurfaceSetTarget(int id);

    [Gml("surface_get_texture", v61)]

    double SurfaceGetTexture(int id);

    [Gml("surface_get_height", v61)]
    double SurfaceGetHeight(int id);

    [Gml("surface_get_width", v61)]
    double SurfaceGetWidth(int id);

    [Gml("surface_exists", v61)]
    bool SurfaceExists(int id);

    [Gml("surface_free", v61)]
    void SurfaceFree(int id);

    [Gml("surface_create", v61)]
    void SurfaceCreate(double w, double h);
}
