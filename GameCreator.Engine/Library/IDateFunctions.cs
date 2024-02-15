using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IDateFunctions
{
    //
    // 5.3a
    //
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
}