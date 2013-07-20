using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.Runtime.Library
{
    // TODO: Implement all GML date-time functions
    public static partial class GmlFunctions
    {
        readonly static DateTime epoch = new DateTime(1899, 12, 30);
        [GmlFunction]
        public static double date_current_datetime()
        {
            return DateTime.Now.Subtract(epoch).TotalDays;
        }

        [GmlFunction]
        public static double date_current_date()
        {
            return Math.Floor(DateTime.Now.Subtract(epoch).TotalDays);
        }

        [GmlFunction]
        public static double date_current_time()
        {
            double val = DateTime.Now.Subtract(epoch).TotalDays;
            return val - Math.Floor(val);
        }

        [GmlFunction]
        public static double date_create_datetime(int year, int month, int day, int hour, int minute, int second)
        {
            try
            {
                return new DateTime(year, month, day, hour, minute, second).Subtract(epoch).TotalDays;
            }
            catch
            {
                return 0;
            }
        }
    }
}
