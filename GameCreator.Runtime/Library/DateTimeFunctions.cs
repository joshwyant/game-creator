using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Interpreter;

namespace GameCreator.Runtime
{
    // TODO: Implement all GML date-time functions
    internal static class DateTimeFunctions
    {
        readonly static DateTime epoch = new DateTime(1899, 12, 30);
        [GMLFunction(0)]
        public static Value date_current_datetime(params Value[] args)
        {
            return new Value(DateTime.Now.Subtract(epoch).TotalDays);
        }
        [GMLFunction(0)]
        public static Value date_current_date(params Value[] args)
        {
            return new Value(Math.Floor(DateTime.Now.Subtract(epoch).TotalDays));
        }
        [GMLFunction(0)]
        public static Value date_current_time(params Value[] args)
        {
            double val = DateTime.Now.Subtract(epoch).TotalDays;
            return new Value(val - Math.Floor(val));
        }
        [GMLFunction(6)]
        public static Value date_create_datetime(params Value[] args)
        {
            try
            {
                return new Value(new DateTime((int)args[0].Real, (int)args[1].Real, (int)args[2].Real, (int)args[3].Real, (int)args[4].Real, (int)args[5].Real).Subtract(epoch).TotalDays);
            }
            catch
            {
                return Value.Zero;
            }
        }
    }
}
