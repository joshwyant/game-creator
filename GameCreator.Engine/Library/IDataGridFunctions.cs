using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDataGridFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 6.1
    //
    [Gml("ds_grid_value_disk_y", v61)]
    double DsGridValueDiskY(int id, double xm, double ym, double r, double val);

    [Gml("ds_grid_value_disk_x", v61)]
    double DsGridValueDiskX(int id, double xm, double ym, double r, double val);

    [Gml("ds_grid_value_disk_exists", v61)]
    bool DsGridValueDiskExists(int id, double xm, double ym, double r, double val);

    [Gml("ds_grid_value_y", v61)]
    double DsGridValueY(int id, double x1, double y1, double x2, double y2, double val);

    [Gml("ds_grid_value_x", v61)]
    double DsGridValueX(int id, double x1, double y1, double x2, double y2, double val);

    [Gml("ds_grid_value_exists", v61)]
    bool DsGridValueExists(int id, double x1, double y1, double x2, double y2, double val);

    [Gml("ds_grid_get_disk_mean", v61)]
    double DsGridGetDiskMean(int id, double xm, double ym, double r);

    [Gml("ds_grid_get_disk_max", v61)]
    double DsGridGetDiskMax(int id, double xm, double ym, double r);

    [Gml("ds_grid_get_disk_min", v61)]
    double DsGridGetDiskMin(int id, double xm, double ym, double r);

    [Gml("ds_grid_get_disk_sum", v61)]
    double DsGridGetDiskSum(int id, double xm, double ym, double r);

    [Gml("ds_grid_get_mean", v61)]
    double DsGridGetMean(int id, double x1, double y1, double x2, double y2);

    [Gml("ds_grid_get_min", v61)]
    double DsGridGetMin(int id, double x1, double y1, double x2, double y2);

    [Gml("ds_grid_get_max", v61)]
    double DsGridGetMax(int id, double x1, double y1, double x2, double y2);

    [Gml("ds_grid_get_sum", v61)]
    double DsGridGetSum(int id, double x1, double y1, double x2, double y2);

    [Gml("ds_grid_get", v61)]
    double DsGridGet(int id, double x, double y);

    [Gml("ds_grid_multiply_disk", v61)]
    void DsGridMultiplyDisk(int id, double xm, double ym, double r, double val);

    [Gml("ds_grid_add_disk", v61)]
    void DsGridAddDisk(int id, double xm, double ym, double r, double val);

    [Gml("ds_grid_set_disk", v61)]
    void DsGridSetDisk(int id, double xm, double ym, double r, double val);

    [Gml("ds_grid_multiply_region", v61)]
    void DsGridMultiplyRegion(int id, double x1, double y1, double x2, double y2, double val);

    [Gml("ds_grid_add_region", v61)]
    void DsGridAddRegion(int id, double x1, double y1, double x2, double y2, double val);

    [Gml("ds_grid_set_region", v61)]
    void DsGridSetRegion(int id, double x1, double y1, double x2, double y2, double val);

    [Gml("ds_grid_multiply", v61)]
    void DsGridMultiply(int id, double x, double y, double val);

    [Gml("ds_grid_add", v61)]
    void DsGridAdd(int id, double x, double y, double val);

    [Gml("ds_grid_set", v61)]
    void DsGridSet(int id, double x, double y, double val);

    [Gml("ds_grid_clear", v61)]
    void DsGridClear(int id, double val);

    [Gml("ds_grid_height", v61)]
    double DsGridHeight(int id);

    [Gml("ds_grid_width", v61)]
    double DsGridWidth(int id);

    [Gml("ds_grid_resize", v61)]
    void DsGridResize(int id, double w, double h);

    [Gml("ds_grid_destroy", v61)]
    void DsGridDestroy(int id);

    [Gml("ds_grid_create", v61)]
    void DsGridCreate(double w, double h);

    //
    // 7.0
    //
    [Gml("ds_grid_read", v70)]
    void DsGridRead(int id, string str);

    [Gml("ds_grid_write", v70)]
    void DsGridWrite(int id);

    [Gml("ds_grid_shuffle", v70)]
    void DsGridShuffle(int id);

    [Gml("ds_grid_copy", v70)]
    void DsGridCopy(int id, int source);
}
