using GameCreator.Engine.Api;

namespace GameCreator.Engine.Library
{
    public interface IDateFunctions
    {
        [Gml("date_current_datetime")] double DateCurrentDateTime();
        
        [Gml("date_current_date")] double DateCurrentDate();
        
        [Gml("date_current_time")] double DateCurrentTime();
        
        [Gml("date_create_datetime")] double DateCreateDateTime(int year, int month, int day, int hour, int minute, int second);
        
        [Gml("date_create_date")] double DateCreateDate(int year, int month, int dat);
        
        [Gml("date_create_time")] double DateCreateTime(int hour, int minute, int second);
        
        [Gml("date_valid_datetime")] bool DateValidDateTime(int year, int month, int day, int hour, int minute, int second);
        
        [Gml("date_valid_date")] bool DateValidDate(int year, int month, int day);
        
        [Gml("date_valid_time")] bool DateValidTime(int hour, int minute, int second);
        
        [Gml("date_inc_year")] double DateIncYear(double date, int amount);
        
        [Gml("date_inc_month")] double DateIncMonth(double date, int amount);
        
        [Gml("date_inc_week")] double DateIncWeek(double date, int amount);
        
        [Gml("date_inc_day")] double DateIncDay(double date, int amount);
        
        [Gml("date_inc_hour")] double DateIncHour(double date, int amount);
        
        [Gml("date_inc_minute")] double DateIncMinute(double date, int amount);
        
        [Gml("date_inc_second")] double DateIncSecond(double date, int amount);
        
        [Gml("date_get_year")] int DateGetYear(double date);
        
        [Gml("date_get_month")] int DateGetMonth(double date);
        
        [Gml("date_get_day")] int DateGetDay(double date);
        
        [Gml("date_get_hour")] int DateGetHour(double date);
        
        [Gml("date_get_minute")] int DateGetMinute(double date);
        
        [Gml("date_get_second")] int DateGetSecond(double date);
        
        [Gml("date_get_weekday")] int DateGetWeekday(double date);
        
        [Gml("date_get_day_of_year")] int DateGetDayOfYear(double date);
        
        [Gml("date_get_hour_of_year")] int DateGetHourOfYear(double date);
        
        [Gml("date_get_minute_of_year")] int DateGetMinuteOfYear(double date);
        
        [Gml("date_get_second_of_year")] int DateGetSecondOfYear(double date);
        
        [Gml("date_year_span")] double DateYearSpan(double date1, double date2);
        
        [Gml("date_month_span")] double DateMonthSpan(double date1, double date2);
        
        [Gml("date_week_span")] double DateWeekSpan(double date1, double date2);
        
        [Gml("date_day_span")] double DateDaySpan(double date1, double date2);
        
        [Gml("date_hour_span")] double DateHourSpan(double date1, double date2);
        
        [Gml("date_minute_span")] double DateMinuteSpan(double date1, double date2);
        
        [Gml("date_second_span")] double DateSecondSpan(double date1, double date2);
        
        [Gml("date_compare_datetime")] int DateCompareDateTime(double date1, double date2);
        
        [Gml("date_compare_date")] int DateCompareDate(double date1, double date2);
        
        [Gml("date_compare_time")] int DateCompareTime(double date1, double date2);
        
        [Gml("date_date_of")] double DateDateOf(double date);
        
        [Gml("date_time_of")] double DateTimeOf(double date);
        
        [Gml("date_datetime_string")] string DateDateTimeString(double date);
        
        [Gml("date_date_string")] string DateDateString();
        
        [Gml("date_time_string")] string DateTimeString();
        
        [Gml("date_days_in_month")] int DateDaysInMonth(double date);
        
        [Gml("date_days_in_year")] int DateDaysInYear(double date);
        
        [Gml("date_leap_year")] bool DateLeapYear(double date);
        
        [Gml("date_is_today")] bool DateIsToday(double date);
    }
    
}