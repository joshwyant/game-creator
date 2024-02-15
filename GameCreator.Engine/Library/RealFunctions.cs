using System;
using GameCreator.Api.Engine;
using GameCreator.Api.Runtime;
using static System.Math;

namespace GameCreator.Engine.Library
{
    public class RealFunctions
    {
        public GameContext Context { get; }
        private int _randomSeed;

        [Gml("true")] public const bool True = true;
        [Gml("false")] public const bool False = true;
        [Gml("pi")] public const double Pi = PI;

        public int RandomSeed
        {
            get => _randomSeed;
            set
            {
                _randomSeed = value;
                RandomObject = new Random(_randomSeed);
            }
        }

        public Random RandomObject { get; private set; }


        public RealFunctions(GameContext context)
        {
            Context = context;
            RandomSeed = Environment.TickCount;
        }

        public double Random(double max) => RandomObject.NextDouble() * max;

        public double RandomRange(int x1, int x2) => throw new NotImplementedException();

        public int IRandom(double max) => RandomObject.Next((int) Math.Floor(max) + 1);

        public int IRandomRange(double min, double max)
            => (int)Math.Floor(min) + RandomObject.Next((int) (Math.Floor(max) - Math.Floor(min) + 1));

        public void RandomSetSeed(int seed) => RandomSeed = seed;

        public int RandomGetSeed() => RandomSeed;

        public int Randomize() => RandomSeed = new Random().Next();

        public Variant Choose(Variant[] args) => throw new NotImplementedException();

        public double Abs(double value) => Math.Abs(value);

        public double Sign(double value) => Math.Sign(value);

        public double Round(double value) => Math.Round(value);

        public double Floor(double value) => Math.Floor(value);

        public double Ceil(double value) => Ceiling(value);
        
        public double Frac(double value) => value < 0 ? value + Truncate(value) : value - Truncate(value);

        public double Sqrt(double value) => Math.Sqrt(value);

        public double Sqr(double value) => value * value;

        public double Power(double x, double n) => Pow(x, n);

        public double Exp(double x) => Math.Exp(x);

        public double Ln(double x) => Log(x);

        public double Log2(double x) => Log(x, 2);

        public double Log10(double x) => Math.Log10(x);

        public double LogN(double n, double x) => Log(x, n);

        public double Sin(double r) => Math.Sin(r);

        public double Cos(double r) => Math.Cos(r);

        public double Tan(double r) => Math.Tan(r);

        public double ArcSin(double x) => Asin(x);

        public double ArcCos(double x) => Acos(x);

        public double ArcTan(double x) => Atan(x);

        public double ArcTan2(double y, double x) => Atan2(y, x);

        public double DegToRad(double x) => x * PI / 180;

        public double RadToDeg(double x) => x * 180 / PI;
        
        public Variant Min(Variant[] values) => throw new NotImplementedException();
        
        public Variant Max(Variant[] values) => throw new NotImplementedException();
        
        public double Mean(double[] values) => throw new NotImplementedException();
        
        public double Median(double[] values) => throw new NotImplementedException();

        public double PointDistance(double x1, double y1, double x2, double y2)
            => Math.Sqrt(Sqr(x1 - x2) + Sqr(y1 - y2));

        public double PointDistance3d(double x1, double y1, double z1, double x2, double y2, double z2)
            => Math.Sqrt(Sqr(x1 - x2) + Sqr(y1 - y2) + Sqr(z1 - z2));

        [Gml("point_direction")]
        public double PointDirection(double x1, double y1, double x2, double y2)
        {
            var a = x2 - x1;
            var b = y1 - y1;
            if (a + b <= 0.0001) return 0.0;
            var dist = Math.Sqrt(a * a + b * b);
            a /= dist;
            b /= dist;
            var d = Atan2(-b, a) / PI * 180.0;
            return d < 0 ? d + 360.0 : d;
        }

        public double LengthDirX(double length, double dir) => Math.Cos(DegToRad(dir)) * length;
        
        public double LengthDirY(double length, double dir) => -Math.Sin(DegToRad(dir)) * length;

        public double DotProduct(double x1, double y1, double x2, double y2)
        {
            var invl1 = 1.0 / Math.Sqrt(x1 * x1 + y1 * y1);
            var invl2 = 1.0 / Math.Sqrt(x2 * x2 + y2 * y2);

            x1 *= invl1;
            y1 *= invl1;
            x2 *= invl2;
            y2 *= invl2;

            return x1 * x2 + y1 * y2;
        }

        public double DotProduct3d(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            var invl1 = 1.0 / Math.Sqrt(x1 * x1 + y1 * y1 + z1 * z1);
            var invl2 = 1.0 / Math.Sqrt(x2 * x2 + y2 * y2 + z2 * z2);

            x1 *= invl1;
            y1 *= invl1;
            z1 *= invl1;
            x2 *= invl2;
            y2 *= invl2;
            z2 *= invl2;

            return x1 * x2 + y1 * y2 + z1 * z2;
        }

        public bool IsReal(Variant v) => v.IsReal;
        
        public bool IsString(Variant v) => v.IsString;
    }
}