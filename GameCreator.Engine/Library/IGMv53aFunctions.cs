using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
min(val1, val2, val3, …)	5.3a
max(val1, val2, val3, …)	5.3a
mean(val1, val2, val3, …)	5.3a
date_current_datetime()	5.3a
date_current_date()	5.3a
date_current_time()	5.3a
date_create_datetime(year, month, day, hour, minute, second)	5.3a
date_create_date(year, month, day)	5.3a
date_create_time(hour, minute, second)	5.3a
date_valid_datetime(year, month, day, hour, minute, second)	5.3a
date_valid_date(year, month, day)	5.3a
date_valid_time(hour, minute, second)	5.3a
date_inc_year(date, amount)	5.3a
date_inc_month(date, amount)	5.3a
date_inc_week(date, amount)	5.3a
date_inc_day(date, amount)	5.3a
date_inc_hour(date, amount)	5.3a
date_inc_minute(date, amount)	5.3a
date_inc_second(date, amount)	5.3a
date_get_year(date)	5.3a
date_get_month(date)	5.3a
date_get_week(date)	5.3a
date_get_day(date)	5.3a
date_get_hour(date)	5.3a
date_get_minute(date)	5.3a
date_get_second(date)	5.3a
date_get_weekday(date)	5.3a
date_get_day_of_year(date)	5.3a
date_get_hour_of_year(date)	5.3a
date_get_minute_of_year(date)	5.3a
date_get_second_of_year(date)	5.3a
date_year_span(date1, date2)	5.3a
date_month_span(date1, date2)	5.3a
date_week_span(date1, date2)	5.3a
date_day_span(date1, date2)	5.3a
date_hour_span(date1, date2)	5.3a
date_minute_span(date1, date2)	5.3a
date_second_span(date1, date2)	5.3a
date_compare_datetime(date1, date2)	5.3a
date_compare_date(date1, date2)	5.3a
date_compare_time(date1, date2)	5.3a
date_date_of(date)	5.3a
date_time_of(date)	5.3a
date_datetime_string(date)	5.3a
date_date_string(date)	5.3a
date_time_string(date)	5.3a
date_days_in_month(date)	5.3a
date_days_in_year(date)	5.3a
date_leap_year(date)	5.3a
date_is_today(date)	5.3a
path_start(path, speed, endaction, absolute)	5.3a
path_end()	5.3a
mp_linear_step(x, y, stepsize, checkall)	5.3a
mp_potential_step(x, y, stepsize, checkall)	5.3a
mp_potential_settings(maxrot, rotstep, ahead, onspot)	5.3a
mp_linear_path(path, xg, yg, stepsize, checkall)	5.3a
mp_potential_path(path, xg, yg, stepsize, checkall, factor)	5.3a
mp_grid_create(left, top, hcells, vcells, cellwidth, cellheight)	5.3a
mp_grid_destroy(id)	5.3a
mp_grid_clear_all(id)	5.3a
mp_grid_clear_cell(id, h, v)	5.3a
mp_grid_clear_rectangle(id, left, top, right, bottom)	5.3a
mp_grid_add_cell(id, h, v)	5.3a
mp_grid_add_rectangle(id, left, top, right, bottom)	5.3a
mp_grid_add_instances(id, obj, prec)	5.3a
mp_grid_path(id, path, xstart, ystart, xgoal, ygoal, allowdiag)	5.3a
mp_grid_draw(id)	5.3a
collision_point(x, y, obj, prec, notme)	5.3a
collision_rectangle(x1, y1, x2, y2, obj, prec, notme)	5.3a
collision_circle(xc, yc, radius, obj, prec, notme)	5.3a
collision_ellipse(x1, y1, x2, y2, obj, prec, notme)	5.3a
collision_line(x1, y1, x2, y2, obj, prec, notme)	5.3a
variable_global_array_get(name, ind)	5.3a
variable_global_array2_get(name, ind1, ind2)	5.3a
variable_local_array_get(name, ind)	5.3a
variable_local_array2_get(name, ind1, ind2)	5.3a
variable_global_array_set(name, ind, value)	5.3a
variable_global_array2_set(name, ind1, ind2, value)	5.3a
variable_local_array_set(name, ind, value)	5.3a
variable_local_array2_set(name, ind1, ind2, value)	5.3a
draw_path(path, x, y, absolute)	5.3a
draw_healthbar(x1, y1, x2, y2, amount, backcol, mincol, maxcol, direction, showback, showborder)	5.3a
make_color_rgb(red, green, blue)	5.3a
make_color_hsv(hue, saturation, value)	5.3a
color_get_red(col)	5.3a
color_get_green(col)	5.3a
color_get_blue(col)	5.3a
color_get_hue(col)	5.3a
color_get_saturation(col)	5.3a
color_get_value(col)	5.3a
merge_color(col1, col2, amount)	5.3a
path_get_closed(ind)	5.3a
path_get_precision(ind)	5.3a
path_get_number(ind)	5.3a
path_get_point_x(ind, n)	5.3a
path_get_point_y(ind, n)	5.3a
path_get_point_speed(ind, n)	5.3a
path_get_x(ind, pos)	5.3a
path_get_y(ind, pos)	5.3a
path_get_speed(ind, pos)	5.3a
path_set_precision(ind, prec)	5.3a
path_set_closed(ind, closed)	5.3a
path_duplicate(ind)	5.3a
path_assign(ind, path)	5.3a
path_insert_point(ind, path)	5.3a
path_change_point(ind, n, x, y, speed)	5.3a
path_delete_point(ind, n)	5.3a
path_reverse(ind)	5.3a
path_mirror(ind)	5.3a
path_flip(ind)	5.3a
path_rotate(ind, angle)	5.3a
path_scale(ind, xscale, yscale)	5.3a
path_shift(ind, xshift, yshift)	5.3a
file_text_open_read(fname)	5.3a
file_text_open_write(fname)	5.3a
file_text_open_append(fname)	5.3a
file_text_close(fileid)	5.3a
file_text_write_string(fileid, str)	5.3a
file_text_write_real(fileid, x)	5.3a
file_text_writeln(fileid)	5.3a
file_text_read_string(fileid)	5.3a
file_text_read_real(fileid)	5.3a
file_text_readln(fileid)	5.3a
file_text_eof(fileid)	5.3a

*/

public interface IGMv53aFunctions
{
    [Gml("min", v53a)]
    double Min(params double[] values);

    [Gml("max", v53a)]
    double Max(params double[] values);

    [Gml("mean", v53a)]
    double Mean(params double[] values);

    [Gml("date_current_datetime", v53a)]
    double DateCurrentDatetime();

    [Gml("date_current_date", v53a)]
    double DateCurrentDate();

    [Gml("date_current_time", v53a)]
    double DateCurrentTime();

    [Gml("date_create_datetime", v53a)]
    double DateCreateDatetime(double year, double month, double day, double hour, double minute, double second);

    [Gml("date_create_date", v53a)]
    double DateCreateDate(double year, double month, double day);

    [Gml("date_create_time", v53a)]
    double DateCreateTime(double hour, double minute, double second);

    [Gml("date_valid_datetime", v53a)]
    double DateValidDatetime(double year, double month, double day, double hour, double minute, double second);

    [Gml("date_valid_date", v53a)]
    double DateValidDate(double year, double month, double day);

    [Gml("date_valid_time", v53a)]
    double DateValidTime(double hour, double minute, double second);

    [Gml("date_inc_year", v53a)]
    double DateIncYear(double date, double amount);

    [Gml("date_inc_month", v53a)]
    double DateIncMonth(double date, double amount);

    [Gml("date_inc_week", v53a)]
    double DateIncWeek(double date, double amount);

    [Gml("date_inc_day", v53a)]
    double DateIncDay(double date, double amount);

    [Gml("date_inc_hour", v53a)]
    double DateIncHour(double date, double amount);

    [Gml("date_inc_minute", v53a)]
    double DateIncMinute(double date, double amount);

    [Gml("date_inc_second", v53a)]
    double DateIncSecond(double date, double amount);

    [Gml("date_get_year", v53a)]
    double DateGetYear(double date);

    [Gml("date_get_month", v53a)]
    double DateGetMonth(double date);

    [Gml("date_get_week", v53a)]
    double DateGetWeek(double date);

    [Gml("date_get_day", v53a)]
    double DateGetDay(double date);

    [Gml("date_get_hour", v53a)]
    double DateGetHour(double date);

    [Gml("date_get_minute", v53a)]
    double DateGetMinute(double date);

    [Gml("date_get_second", v53a)]
    double DateGetSecond(double date);

    [Gml("date_get_weekday", v53a)]
    double DateGetWeekday(double date);

    [Gml("date_get_day_of_year", v53a)]
    double DateGetDayOfYear(double date);

    [Gml("date_get_hour_of_year", v53a)]
    double DateGetHourOfYear(double date);

    [Gml("date_get_minute_of_year", v53a)]
    double DateGetMinuteOfYear(double date);

    [Gml("date_get_second_of_year", v53a)]
    double DateGetSecondOfYear(double date);

    [Gml("date_year_span", v53a)]
    double DateYearSpan(double date1, double date2);

    [Gml("date_month_span", v53a)]
    double DateMonthSpan(double date1, double date2);

    [Gml("date_week_span", v53a)]
    double DateWeekSpan(double date1, double date2);

    [Gml("date_day_span", v53a)]
    double DateDaySpan(double date1, double date2);

    [Gml("date_hour_span", v53a)]
    double DateHourSpan(double date1, double date2);

    [Gml("date_minute_span", v53a)]
    double DateMinuteSpan(double date1, double date2);

    [Gml("date_second_span", v53a)]
    double DateSecondSpan(double date1, double date2);

    [Gml("date_compare_datetime", v53a)]
    double DateCompareDatetime(double date1, double date2);

    [Gml("date_compare_date", v53a)]
    double DateCompareDate(double date1, double date2);

    [Gml("date_compare_time", v53a)]
    double DateCompareTime(double date1, double date2);

    [Gml("date_date_of", v53a)]
    double DateDateOf(double date);

    [Gml("date_time_of", v53a)]
    double DateTimeOf(double date);

    [Gml("date_datetime_string", v53a)]
    double DateDatetimeString(double date);

    [Gml("date_date_string", v53a)]
    double DateDateString(double date);

    [Gml("date_time_string", v53a)]
    double DateTimeString(double date);

    [Gml("date_days_in_month", v53a)]
    double DateDaysInMonth(double date);

    [Gml("date_days_in_year", v53a)]
    double DateDaysInYear(double date);

    [Gml("date_leap_year", v53a)]
    double DateLeapYear(double date);

    [Gml("date_is_today", v53a)]
    double DateIsToday(double date);

    [Gml("path_start", v53a)]
    double PathStart(double path, double speed, double endaction, double absolute);

    [Gml("path_end", v53a)]
    double PathEnd();

    [Gml("mp_linear_step", v53a)]
    double MpLinearStep(double x, double y, double stepsize, double checkall);

    [Gml("mp_potential_step", v53a)]
    double MpPotentialStep(double x, double y, double stepsize, double checkall);

    [Gml("mp_potential_settings", v53a)]
    double MpPotentialSettings(double maxrot, double rotstep, double ahead, double onspot);

    [Gml("mp_linear_path", v53a)]
    double MpLinearPath(double path, double xg, double yg, double stepsize, double checkall);

    [Gml("mp_potential_path", v53a)]
    double MpPotentialPath(double path, double xg, double yg, double stepsize, double checkall, double factor);

    [Gml("mp_grid_create", v53a)]
    double MpGridCreate(double left, double top, double hcells, double vcells, double cellwidth, double cellheight);

    [Gml("mp_grid_destroy", v53a)]
    double MpGridDestroy(double id);

    [Gml("mp_grid_clear_all", v53a)]
    double MpGridClearAll(double id);

    [Gml("mp_grid_clear_cell", v53a)]
    double MpGridClearCell(double id, double h, double v);

    [Gml("mp_grid_clear_rectangle", v53a)]
    double MpGridClearRectangle(double id, double left, double top, double right, double bottom);

    [Gml("mp_grid_add_cell", v53a)]
    double MpGridAddCell(double id, double h, double v);

    [Gml("mp_grid_add_rectangle", v53a)]
    double MpGridAddRectangle(double id, double left, double top, double right, double bottom);

    [Gml("mp_grid_add_instances", v53a)]
    double MpGridAddInstances(double id, double obj, double prec);

    [Gml("mp_grid_path", v53a)]
    double MpGridPath(double id, double path, double xstart, double ystart, double xgoal, double ygoal, double allowdiag);

    [Gml("mp_grid_draw", v53a)]
    double MpGridDraw(double id);

    [Gml("collision_point", v53a)]
    double CollisionPoint(double x, double y, double obj, double prec, double notme);

    [Gml("collision_rectangle", v53a)]
    double CollisionRectangle(double x1, double y1, double x2, double y2, double obj, double prec, double notme);

    [Gml("collision_circle", v53a)]
    double CollisionCircle(double xc, double yc, double radius, double obj, double prec, double notme);

    [Gml("collision_ellipse", v53a)]
    double CollisionEllipse(double x1, double y1, double x2, double y2, double obj, double prec, double notme);

    [Gml("collision_line", v53a)]
    double CollisionLine(double x1, double y1, double x2, double y2, double obj, double prec, double notme);

    [Gml("variable_global_array_get", v53a)]
    double VariableGlobalArrayGet(double name, double ind);

    [Gml("variable_global_array2_get", v53a)]
    double VariableGlobalArray2Get(double name, double ind1, double ind2);

    [Gml("variable_local_array_get", v53a)]
    double VariableLocalArrayGet(double name, double ind);

    [Gml("variable_local_array2_get", v53a)]
    double VariableLocalArray2Get(double name, double ind1, double ind2);

    [Gml("variable_global_array_set", v53a)]
    double VariableGlobalArraySet(double name, double ind, double value);

    [Gml("variable_global_array2_set", v53a)]
    double VariableGlobalArray2Set(double name, double ind1, double ind2, double value);

    [Gml("variable_local_array_set", v53a)]
    double VariableLocalArraySet(double name, double ind, double value);

    [Gml("variable_local_array2_set", v53a)]
    double VariableLocalArray2Set(double name, double ind1, double ind2, double value);

    [Gml("draw_path", v53a)]
    double DrawPath(double path, double x, double y, double absolute);

    [Gml("draw_healthbar", v53a)]
    double DrawHealthbar(double x1, double y1, double x2, double y2, double amount, double backcol, double mincol, double maxcol, double direction, double showback, double showborder);

    [Gml("make_color_rgb", v53a)]
    double MakeColorRgb(double red, double green, double blue);

    [Gml("make_color_hsv", v53a)]
    double MakeColorHsv(double hue, double saturation, double value);

    [Gml("color_get_red", v53a)]
    double ColorGetRed(double col);

    [Gml("color_get_green", v53a)]
    double ColorGetGreen(double col);

    [Gml("color_get_blue", v53a)]
    double ColorGetBlue(double col);

    [Gml("color_get_hue", v53a)]
    double ColorGetHue(double col);

    [Gml("color_get_saturation", v53a)]
    double ColorGetSaturation(double col);

    [Gml("color_get_value", v53a)]
    double ColorGetValue(double col);

    [Gml("merge_color", v53a)]
    double MergeColor(double col1, double col2, double amount);

    [Gml("path_get_closed", v53a)]
    double PathGetClosed(double ind);

    [Gml("path_get_precision", v53a)]
    double PathGetPrecision(double ind);

    [Gml("path_get_number", v53a)]
    double PathGetNumber(double ind);

    [Gml("path_get_point_x", v53a)]
    double PathGetPointX(double ind, double n);

    [Gml("path_get_point_y", v53a)]
    double PathGetPointY(double ind, double n);

    [Gml("path_get_point_speed", v53a)]
    double PathGetPointSpeed(double ind, double n);

    [Gml("path_get_x", v53a)]
    double PathGetX(double ind, double pos);

    [Gml("path_get_y", v53a)]
    double PathGetY(double ind, double pos);

    [Gml("path_get_speed", v53a)]
    double PathGetSpeed(double ind, double pos);

    [Gml("path_set_precision", v53a)]
    double PathSetPrecision(double ind, double prec);

    [Gml("path_set_closed", v53a)]
    double PathSetClosed(double ind, double closed);

    [Gml("path_duplicate", v53a)]
    double PathDuplicate(double ind);

    [Gml("path_assign", v53a)]
    double PathAssign(double ind, double path);

    [Gml("path_insert_point", v53a)]
    double PathInsertPoint(double ind, double path);

    [Gml("path_change_point", v53a)]
    double PathChangePoint(double ind, double n, double x, double y, double speed);

    [Gml("path_delete_point", v53a)]
    double PathDeletePoint(double ind, double n);

    [Gml("path_reverse", v53a)]
    double PathReverse(double ind);

    [Gml("path_mirror", v53a)]
    double PathMirror(double ind);

    [Gml("path_flip", v53a)]
    double PathFlip(double ind);

    [Gml("path_rotate", v53a)]
    double PathRotate(double ind, double angle);

    [Gml("path_scale", v53a)]
    double PathScale(double ind, double xscale, double yscale);

    [Gml("path_shift", v53a)]
    double PathShift(double ind, double xshift, double yshift);

    [Gml("file_text_open_read", v53a)]
    double FileTextOpenRead(double fname);

    [Gml("file_text_open_write", v53a)]
    double FileTextOpenWrite(double fname);

    [Gml("file_text_open_append", v53a)]
    double FileTextOpenAppend(double fname);

    [Gml("file_text_close", v53a)]
    double FileTextClose(double fileid);

    [Gml("file_text_write_string", v53a)]
    double FileTextWriteString(double fileid, double str);

    [Gml("file_text_write_real", v53a)]
    double FileTextWriteReal(double fileid, double x);

    [Gml("file_text_writeln", v53a)]
    double FileTextWriteln(double fileid);

    [Gml("file_text_read_string", v53a)]
    double FileTextReadString(double fileid);

    [Gml("file_text_read_real", v53a)]
    double FileTextReadReal(double fileid);

    [Gml("file_text_readln", v53a)]
    double FileTextReadln(double fileid);

    [Gml("file_text_eof", v53a)]
    double FileTextEof(double fileid);
}
