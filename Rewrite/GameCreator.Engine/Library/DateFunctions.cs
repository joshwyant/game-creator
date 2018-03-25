using System;

namespace GameCreator.Engine.Library
{
    public class DateFunctions : IDateFunctions
    {
        public GameContext Context { get; }

        public DateFunctions(GameContext context)
        {
            Context = context;
        }
        
        public double DateCurrentDateTime() => throw new NotImplementedException();
        
        public double DateCurrentDate() => throw new NotImplementedException();
        
        public double DateCurrentTime() => throw new NotImplementedException();
        
        public double DateCreateDateTime(int year, int month, int day, int hour, int minute, int second) 
            => throw new NotImplementedException();
        
        public double DateCreateDate(int year, int month, int dat) => throw new NotImplementedException();
        
        public double DateCreateTime(int hour, int minute, int second) => throw new NotImplementedException();
        
        public bool DateValidDateTime(int year, int month, int day, int hour, int minute, int second)
            => throw new NotImplementedException();
        
        public bool DateValidDate(int year, int month, int day) => throw new NotImplementedException();
        
        public bool DateValidTime(int hour, int minute, int second) => throw new NotImplementedException();
        
        public double DateIncYear(double date, int amount) => throw new NotImplementedException();
        
        public double DateIncMonth(double date, int amount) => throw new NotImplementedException();
        
        public double DateIncWeek(double date, int amount) => throw new NotImplementedException();
        
        public double DateIncDay(double date, int amount) => throw new NotImplementedException();
        
        public double DateIncHour(double date, int amount) => throw new NotImplementedException();
        
        public double DateIncMinute(double date, int amount) => throw new NotImplementedException();
        
        public double DateIncSecond(double date, int amount) => throw new NotImplementedException();
        
        public int DateGetYear(double date) => throw new NotImplementedException();
        
        public int DateGetMonth(double date) => throw new NotImplementedException();
        
        public int DateGetDay(double date) => throw new NotImplementedException();
        
        public int DateGetHour(double date) => throw new NotImplementedException();
        
        public int DateGetMinute(double date) => throw new NotImplementedException();
        
        public int DateGetSecond(double date) => throw new NotImplementedException();
        
        public int DateGetWeekday(double date) => throw new NotImplementedException();
        
        public int DateGetDayOfYear(double date) => throw new NotImplementedException();
        
        public int DateGetHourOfYear(double date) => throw new NotImplementedException();
        
        public int DateGetMinuteOfYear(double date) => throw new NotImplementedException();
        
        public int DateGetSecondOfYear(double date) => throw new NotImplementedException();
        
        public double DateYearSpan(double date1, double date2) => throw new NotImplementedException();
        
        public double DateMonthSpan(double date1, double date2) => throw new NotImplementedException();
        
        public double DateWeekSpan(double date1, double date2) => throw new NotImplementedException();
        
        public double DateDaySpan(double date1, double date2) => throw new NotImplementedException();
        
        public double DateHourSpan(double date1, double date2) => throw new NotImplementedException();
        
        public double DateMinuteSpan(double date1, double date2) => throw new NotImplementedException();
        
        public double DateSecondSpan(double date1, double date2) => throw new NotImplementedException();
        
        public int DateCompareDateTime(double date1, double date2) => throw new NotImplementedException();
        
        public int DateCompareDate(double date1, double date2) => throw new NotImplementedException();
        
        public int DateCompareTime(double date1, double date2) => throw new NotImplementedException();
        
        public double DateDateOf(double date) => throw new NotImplementedException();
        
        public double DateTimeOf(double date) => throw new NotImplementedException();
        
        public string DateDateTimeString(double date) => throw new NotImplementedException();
        
        public string DateDateString() => throw new NotImplementedException();
        
        public string DateTimeString() => throw new NotImplementedException();
        
        public int DateDaysInMonth(double date) => throw new NotImplementedException();
        
        public int DateDaysInYear(double date) => throw new NotImplementedException();
        
        public bool DateLeapYear(double date) => throw new NotImplementedException();
        
        public bool DateIsToday(double date) => throw new NotImplementedException();
    }
}