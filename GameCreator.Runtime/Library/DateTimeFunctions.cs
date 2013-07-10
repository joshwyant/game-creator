using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework.Gml;

namespace GameCreator.Framework.Library
{
    // TODO: Implement all GML date-time functions
    internal static partial class GMLFunctions
    {
        readonly static DateTime epoch = new DateTime(1899, 12, 30);
        [GMLFunction(0)]
        public static Value date_current_datetime(params Value[] args)
        {
            return DateTime.Now.Subtract(epoch).TotalDays;
        }
        [GMLFunction(0)]
        public static Value date_current_date(params Value[] args)
        {
            return Math.Floor(DateTime.Now.Subtract(epoch).TotalDays);
        }
        [GMLFunction(0)]
        public static Value date_current_time(params Value[] args)
        {
            double val = DateTime.Now.Subtract(epoch).TotalDays;
            return val - Math.Floor(val);
        }
        [GMLFunction(6)]
        public static Value date_create_datetime(params Value[] args)
        {
            try
            {
                return new DateTime(args[0], args[1], args[2], args[3], args[4], args[5]).Subtract(epoch).TotalDays;
            }
            catch
            {
                return 0;
            }
        }
    }
}
