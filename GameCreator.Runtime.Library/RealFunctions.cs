using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.Runtime.Library
{
    // GML Real double functions
    internal static partial class GMLFunctions
    {
        public static int rndseed = System.Environment.TickCount;
        public static Random rnd = new Random(rndseed);

        #region Real-valued functions
        [GmlFunction]
        public static double random(double max)
        {
            return rnd.NextDouble() * max;
        }

        [GmlFunction]
        public static void random_set_seed(int seed)
        {
            rnd = new Random(seed);
        }

        [GmlFunction]
        public static int random_get_seed()
        {
            return rndseed;
        }

        [GmlFunction]
        public static void randomize()
        {
            rndseed = System.Environment.TickCount;
            rnd = new Random(unchecked((int)rndseed));
        }

        [GmlFunction]
        public static Value choose(params Value[] args)
        {
            return args[rnd.Next(args.Length)];
        }

        [GmlFunction]
        public static double abs(double val)
        {
            return Math.Abs(val);
        }

        [GmlFunction]
        public static int sign(double val)
        {
            return Math.Sign(val);
        }

        [GmlFunction]
        public static double round(double val)
        {
            return Math.Round(val);
        }

        [GmlFunction]
        public static double floor(double val)
        {
            return Math.Floor(val);
        }

        [GmlFunction]
        public static double ceil(double val)
        {
            return Math.Ceiling(val);
        }

        [GmlFunction]
        public static double frac(double d)
        {
            return d < 0 ? d + Math.Truncate(d) : d - Math.Truncate(d);
        }

        [GmlFunction]
        public static double sqrt(double val)
        {
            return Math.Sqrt(val);
        }

        [GmlFunction]
        public static double sqr(double val)
        {
            return val*val;
        }

        [GmlFunction]
        public static double power(double x, double y)
        {
            return Math.Pow(x, y);
        }

        [GmlFunction]
        public static double exp(double val)
        {
            return Math.Exp(val);
        }

        [GmlFunction]
        public static double ln(double val)
        {
            return Math.Log(val);
        }

        [GmlFunction]
        public static double log2(double val)
        {
            return Math.Log(val, 2.0);
        }

        [GmlFunction]
        public static double log10(double val)
        {
            return Math.Log10(val);
        }

        [GmlFunction]
        public static double logn(double a, double newBase)
        {
            return Math.Log(a, newBase);
        }

        [GmlFunction]
        public static double sin(double val)
        {
            return Math.Sin(val);
        }

        [GmlFunction]
        public static double cos(double val)
        {
            return Math.Cos(val);
        }

        [GmlFunction]
        public static double tan(double val)
        {
            return Math.Tan(val);
        }

        [GmlFunction]
        public static double arccos(double val)
        {
            return Math.Acos(val);
        }

        [GmlFunction]
        public static double arcsin(double val)
        {
            return Math.Asin(val);
        }

        [GmlFunction]
        public static double arctan(double val)
        {
            return Math.Atan(val);
        }

        [GmlFunction]
        public static double arctan2(double y, double x)
        {
            return Math.Atan2(y, x);
        }

        [GmlFunction]
        public static double degtorad(double val)
        {
            return val * Math.PI / 180.0;
        }

        [GmlFunction]
        public static double radtodeg(double val)
        {
            return val / Math.PI * 180.0;
        }

        [GmlFunction]
        public static Value min(params Value[] args)
        {
            bool real = false, str = false;
            var min_real = 0.0;
            var min_str = string.Empty;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].IsString)
                {
                    if (!str) min_str = args[i];
                    else if (string.CompareOrdinal(args[i], min_str) < 0) min_str = args[i];
                    str = true;
                }
                else
                {
                    if (!real) min_real = args[i];
                    else if (args[i] < min_real) min_real = args[i];
                    real = true;
                }
            }
            return str && !real ? (Value)min_str : (Value)min_real;
        }

        [GmlFunction]
        public static Value max(params Value[] args)
        {
            bool real = false, str = false;
            var max_real = 0.0;
            var max_str = string.Empty;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].IsString)
                {
                    if (str == false) max_str = args[i];
                    else if (string.CompareOrdinal(args[i], max_str) > 0) max_str = args[i];
                    str = true;
                }
                else
                {
                    if (real == false) max_real = args[i];
                    else if (args[i] > max_real) max_real = args[i];
                    real = true;
                }
            }
            return str ? (Value)max_str : (Value)max_real;
        }

        [GmlFunction]
        public static double mean(params double[] args)
        {
            if (args.Length == 0) return 0;
            var d = 0.0;
            foreach (var v in args)
                d += v;
            return d/(double)args.Length;
        }

        [GmlFunction]
        public static double median(params double[] args)
        {
            Array.Sort<double>(args);
            return args.Length % 2 == 1 ? args[args.Length/2] : args[args.Length/2-1];
        }

        [GmlFunction]
        public static double point_distance(double x1, double y1, double x2, double y2)
        {
            var a = x2 - x1;
            var b = y2 - y1;
            return Math.Sqrt(a * a + b * b);
        }

        [GmlFunction]
        public static double point_direction(double x1, double y1, double x2, double y2)
        {
            var a = x2 - x1;
            var b = y1 - y1;
            var dist = Math.Sqrt(a * a + b * b);
            if (dist == 0.0) return 0.0;
            a /= dist;
            b /= dist;
            var d = Math.Atan2(-b, a) / Math.PI * 180.0;
            return d < 0 ? d + 360.0 : d;
        }

        [GmlFunction]
        public static double lengthdir_x(double length, double dir)
        {
            return Math.Cos(dir * Math.PI / 180.0) * length;
        }

        [GmlFunction]
        public static double lengthdir_y(double length, double dir)
        {
            return -Math.Sin(dir * Math.PI / 180.0) * length;
        }

        [GmlFunction]
        public static double is_real(Value val)
        {
            return val.IsReal ? 1.0 : 0.0;
        }

        [GmlFunction]
        public static double is_string(Value val)
        {
            return val.IsString ? 1.0 : 0.0;
        }
        #endregion
    }
}
