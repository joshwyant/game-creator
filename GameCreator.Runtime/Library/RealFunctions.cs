using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework.Gml;

namespace GameCreator.Framework.Library
{
    // GML Real value functions
    internal static partial class GMLFunctions
    {
        public static double rndseed = (double)System.Environment.TickCount;
        public static Random rnd = new Random(unchecked((int)rndseed));
        #region Real-valued functions
        [GMLFunction(1)]
        public static Value random(params Value[] args)
        {
            return rnd.NextDouble() * args[0];
        }
        [GMLFunction(1)]
        public static Value random_set_seed(params Value[] args)
        {
            rndseed = args[0];
            rnd = new Random(unchecked((int)rndseed));
            return Value.Null;
        }
        [GMLFunction(0)]
        public static Value random_get_seed(params Value[] args)
        {
            return rndseed;
        }
        [GMLFunction(0)]
        public static Value randomize(params Value[] args)
        {
            rndseed = (double)System.Environment.TickCount;
            rnd = new Random(unchecked((int)rndseed));
            return new Value();
        }
        [GMLFunction(-1)]
        public static Value choose(params Value[] args)
        {
            return args[rnd.Next(args.Length)];
        }
        [GMLFunction(1)]
        public static Value abs(params Value[] args)
        {
            return Math.Abs(args[0].Real);
        }
        [GMLFunction(1)]
        public static Value sign(params Value[] args)
        {
            return Math.Sign(args[0].Real);
        }
        [GMLFunction(1)]
        public static Value round(params Value[] args)
        {
            return Math.Round(args[0].Real);
        }
        [GMLFunction(1)]
        public static Value floor(params Value[] args)
        {
            return Math.Floor(args[0].Real);
        }
        [GMLFunction(1)]
        public static Value ceil(params Value[] args)
        {
            return Math.Ceiling(args[0].Real);
        }
        [GMLFunction(1)]
        public static Value frac(params Value[] args)
        {
            double d = args[0].Real;
            return d < 0 ? d + Math.Truncate(d) : d - Math.Truncate(d);
        }
        [GMLFunction(1)]
        public static Value sqrt(params Value[] args)
        {
            return Math.Sqrt(args[0].Real);
        }
        [GMLFunction(1)]
        public static Value sqr(params Value[] args)
        {
            return args[0].Real*args[0].Real;
        }
        [GMLFunction(2)]
        public static Value power(params Value[] args)
        {
            return Math.Pow(args[0], args[1]);
        }
        [GMLFunction(1)]
        public static Value exp(params Value[] args)
        {
            return Math.Exp(args[0]);
        }
        [GMLFunction(1)]
        public static Value ln(params Value[] args)
        {
            return Math.Log(args[0]);
        }
        [GMLFunction(1)]
        public static Value log2(params Value[] args)
        {
            return Math.Log(args[0], 2.0);
        }
        [GMLFunction(1)]
        public static Value log10(params Value[] args)
        {
            return Math.Log10(args[0]);
        }
        [GMLFunction(2)]
        public static Value logn(params Value[] args)
        {
            return Math.Log(args[1], args[0]);
        }
        [GMLFunction(1)]
        public static Value sin(params Value[] args)
        {
            return Math.Sin(args[0]);
        }
        [GMLFunction(1)]
        public static Value cos(params Value[] args)
        {
            return Math.Cos(args[0]);
        }
        [GMLFunction(1)]
        public static Value tan(params Value[] args)
        {
            return Math.Tan(args[0]);
        }
        [GMLFunction(1)]
        public static Value arccos(params Value[] args)
        {
            return Math.Acos(args[0]);
        }
        [GMLFunction(1)]
        public static Value arcsin(params Value[] args)
        {
            return Math.Asin(args[0]);
        }
        [GMLFunction(1)]
        public static Value arctan(params Value[] args)
        {
            return Math.Atan(args[0]);
        }
        [GMLFunction(2)]
        public static Value arctan2(params Value[] args)
        {
            return Math.Atan2(args[0], args[1]);
        }
        [GMLFunction(1)]
        public static Value degtorad(params Value[] args)
        {
            return args[0] * Math.PI / 180.0;
        }
        [GMLFunction(1)]
        public static Value radtodeg(params Value[] args)
        {
            return args[0] / Math.PI * 180.0;
        }
        [GMLFunction(-1)]
        public static Value min(params Value[] args)
        {
            bool real = false, str = false;
            double min_real = 0.0;
            string min_str = string.Empty;
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
        [GMLFunction(-1)]
        public static Value max(params Value[] args)
        {
            bool real = false, str = false;
            double max_real = 0.0;
            string max_str = String.Empty;
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
        [GMLFunction(-1)]
        public static Value mean(params Value[] args)
        {
            if (args.Length == 0) return 0;
            double d = 0;
            foreach (Value v in args)
                d += v;
            return d/(double)args.Length;
        }
        [GMLFunction(-1)]
        public static Value median(params Value[] args)
        {
            List<double> dl = new List<double>();
            foreach (Value v in args)
                dl.Add(v);
            double[] d = dl.ToArray();
            Array.Sort<double>(d);
            return args.Length % 2 == 1 ? d[d.Length/2] : d[d.Length/2-1];
        }
        [GMLFunction(4)]
        public static Value point_distance(params Value[] args)
        {
            double a = args[2] - args[0];
            double b = args[3] - args[1];
            return Math.Sqrt(a * a + b * b);
        }
        [GMLFunction(4)]
        public static Value point_direction(params Value[] args)
        {
            double a = args[2] - args[0];
            double b = args[3] - args[1];
            double dist = Math.Sqrt(a * a + b * b);
            if (dist == 0.0) return 0.0;
            a /= dist;
            b /= dist;
            double d = Math.Atan2(-b, a) / Math.PI * 180.0;
            return d < 0 ? d + 360.0 : d;
        }
        [GMLFunction(2)]
        public static Value lengthdir_x(params Value[] args)
        {
            return Math.Cos(args[1] * Math.PI / 180.0) * args[0];
        }
        [GMLFunction(2)]
        public static Value lengthdir_y(params Value[] args)
        {
            return -Math.Sin(args[1] * Math.PI / 180.0) * args[0];
        }
        [GMLFunction(1)]
        public static Value is_real(params Value[] args)
        {
            return args[0].IsReal ? 1.0 : 0.0;
        }
        [GMLFunction(1)]
        public static Value is_string(params Value[] args)
        {
            return args[0].IsString ? 1.0 : 0.0;
        }
        #endregion
    }
}
