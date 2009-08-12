using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Interpreter;

namespace GameCreator.Runtime
{
    // GML Real value functions
    internal static class RealFunctions
    {
        public static double rndseed = (double)System.Environment.TickCount;
        public static Random rnd = new Random(unchecked((int)rndseed));
        #region Real-valued functions
        [GMLFunction(1)]
        public static Value random(params Value[] args)
        {
            return new Value(rnd.NextDouble() * args[0].Real);
        }
        [GMLFunction(1)]
        public static Value random_set_seed(params Value[] args)
        {
            rndseed = args[0].Real;
            rnd = new Random(unchecked((int)rndseed));
            return new Value();
        }
        [GMLFunction(0)]
        public static Value random_get_seed(params Value[] args)
        {
            return new Value(rndseed);
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
            return new Value(Math.Abs(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value sign(params Value[] args)
        {
            return new Value(Math.Sign(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value round(params Value[] args)
        {
            return new Value(Math.Round(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value floor(params Value[] args)
        {
            return new Value(Math.Floor(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value ceil(params Value[] args)
        {
            return new Value(Math.Ceiling(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value frac(params Value[] args)
        {
            double d = args[0].Real;
            return new Value(d < 0 ? d + Math.Truncate(d) : d - Math.Truncate(d));
        }
        [GMLFunction(1)]
        public static Value sqrt(params Value[] args)
        {
            return new Value(Math.Sqrt(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value sqr(params Value[] args)
        {
            return new Value(args[0].Real*args[0].Real);
        }
        [GMLFunction(2)]
        public static Value power(params Value[] args)
        {
            return new Value(Math.Pow(args[0].Real, args[1].Real));
        }
        [GMLFunction(1)]
        public static Value exp(params Value[] args)
        {
            return new Value(Math.Exp(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value ln(params Value[] args)
        {
            return new Value(Math.Log(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value log2(params Value[] args)
        {
            return new Value(Math.Log(args[0].Real, 2.0));
        }
        [GMLFunction(1)]
        public static Value log10(params Value[] args)
        {
            return new Value(Math.Log10(args[0].Real));
        }
        [GMLFunction(2)]
        public static Value logn(params Value[] args)
        {
            return new Value(Math.Log(args[1].Real, args[0].Real));
        }
        [GMLFunction(1)]
        public static Value sin(params Value[] args)
        {
            return new Value(Math.Sin(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value cos(params Value[] args)
        {
            return new Value(Math.Cos(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value tan(params Value[] args)
        {
            return new Value(Math.Tan(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value arccos(params Value[] args)
        {
            return new Value(Math.Acos(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value arcsin(params Value[] args)
        {
            return new Value(Math.Asin(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value arctan(params Value[] args)
        {
            return new Value(Math.Atan(args[0].Real));
        }
        [GMLFunction(2)]
        public static Value arctan2(params Value[] args)
        {
            return new Value(Math.Atan2(args[0].Real, args[1].Real));
        }
        [GMLFunction(1)]
        public static Value degtorad(params Value[] args)
        {
            return new Value(args[0].Real*Math.PI/180.0);
        }
        [GMLFunction(1)]
        public static Value radtodeg(params Value[] args)
        {
            return new Value(args[0].Real/Math.PI*180.0);
        }
        [GMLFunction(-1)]
        public static Value min(params Value[] args)
        {
            bool real = false, str = false;
            double min_real = 0.0;
            string min_str = String.Empty;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].IsString)
                {
                    if (!str) min_str = args[i].String;
                    else if (string.CompareOrdinal(args[i].String, min_str) < 0) min_str = args[i].String;
                    str = true;
                }
                else
                {
                    if (!real) min_real = args[i].Real;
                    else if (args[i].Real < min_real) min_real = args[i].Real;
                    real = true;
                }
            }
            return str && !real ? new Value(min_str) : new Value(min_real);
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
                    if (str == false) max_str = args[i].String;
                    else if (string.CompareOrdinal(args[i].String, max_str) > 0) max_str = args[i].String;
                    str = true;
                }
                else
                {
                    if (real == false) max_real = args[i].Real;
                    else if (args[i].Real > max_real) max_real = args[i].Real;
                    real = true;
                }
            }
            return str ? new Value(max_str) : new Value(max_real);
        }
        [GMLFunction(-1)]
        public static Value mean(params Value[] args)
        {
            if (args.Length == 0) return Value.Zero;
            double d = 0;
            foreach (Value v in args)
                d += v.Real;
            return new Value(d/(double)args.Length);
        }
        [GMLFunction(-1)]
        public static Value median(params Value[] args)
        {
            List<double> dl = new List<double>();
            foreach (Value v in args)
                dl.Add(v.Real);
            double[] d = dl.ToArray();
            Array.Sort<double>(d);
            return args.Length % 2 == 1 ? new Value(d[d.Length/2]) : new Value(d[d.Length/2-1]);
        }
        [GMLFunction(4)]
        public static Value point_distance(params Value[] args)
        {
            double a = args[2].Real - args[0].Real;
            double b = args[3].Real - args[1].Real;
            return new Value(Math.Sqrt(a*a+b*b));
        }
        [GMLFunction(4)]
        public static Value point_direction(params Value[] args)
        {
            double a = args[2].Real - args[0].Real;
            double b = args[3].Real - args[1].Real;
            double dist = Math.Sqrt(a*a+b*b);
            if (dist == 0.0) return Value.Zero;
            a /= dist;
            b /= dist;
            double d = Math.Atan2(-b, a) / Math.PI * 180.0;
            return new Value(d < 0 ? d + 360.0 : d);
        }
        [GMLFunction(2)]
        public static Value lengthdir_x(params Value[] args)
        {
            return new Value(Math.Cos(args[1].Real * Math.PI / 180.0) * args[0].Real);
        }
        [GMLFunction(2)]
        public static Value lengthdir_y(params Value[] args)
        {
            return new Value(-Math.Sin(args[1].Real * Math.PI / 180.0) * args[0].Real);
        }
        [GMLFunction(1)]
        public static Value is_real(params Value[] args)
        {
            return new Value(args[0].IsReal ? 1.0 : 0.0);
        }
        [GMLFunction(1)]
        public static Value is_string(params Value[] args)
        {
            return new Value(args[0].IsString ? 1.0 : 0.0);
        }
        #endregion
    }
}
