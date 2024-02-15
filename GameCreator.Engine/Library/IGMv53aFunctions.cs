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
}
