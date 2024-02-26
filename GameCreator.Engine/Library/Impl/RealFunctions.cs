using System;
using System.Linq;
using GameCreator.Api.Runtime;
using GameCreator.Engine.Library;
namespace GameCreator.Engine;
public class RealFunctions : IRealFunctions
{
    protected int randomSeed;
    protected Random random;
    public RealFunctions()
    {
        RandomSetSeed(new Random().Next());
    }
    public double Abs(double value) => Math.Abs(value);
    public double ArcCos(double x) => Math.Acos(x);
    public double ArcSin(double x) => Math.Asin(x);
    public double ArcTan(double x) => Math.Atan(x);
    public double ArcTan2(double y, double x) => Math.Atan2(y, x);
    public double Ceil(double value) => Math.Ceiling(value);
    public Variant Choose(Variant[] args) => args[random.Next(args.Length)];
    public double Cos(double r) => Math.Cos(r);
    public double DegToRad(double x) => x * Math.PI / 180;
    public double DotProduct(double x1, double y1, double x2, double y2) => x1 * x2 + y1 * y2;
    public double DotProduct3d(double x1, double y1, double z1, double x2, double y2, double z2) => x1 * x2 + y1 * y2 + z1 * z2;
    public double Exp(double x) => Math.Exp(x);
    public double Floor(double value) => Math.Floor(value);
    public double Frac(double value) => value < 0 ? value - Math.Floor(value) : value - Math.Ceiling(value);
    public int IRandom(int max) => random.Next(max);
    public int IRandomRange(int min, int max) => random.Next(min, max + 1);
    public bool IsReal(Variant v) => v.IsReal;
    public bool IsString(Variant v) => v.IsString;
    public double LengthDirX(double length, double dir) => length * Math.Cos(dir * Math.PI / 180);
    public double LengthDirY(double length, double dir) => -length * Math.Sin(dir * Math.PI / 180);
    public double Ln(double x) => Math.Log(x);
    public double Log10(double x) => Math.Log10(x);
    public double Log2(double x) => Math.Log(x, 2);
    public double LogN(double n, double x) => Math.Log(x, n);
    public Variant Max(Variant[] values) => values.Select(v => v.IsReal).Max();
    public double Mean(double[] values) => values.Sum() / values.Length;
    public double Median(double[] values)
    {
        Array.Sort(values);
        return values.Length % 2 == 0
            ? (values[values.Length / 2] + values[values.Length / 2 - 1]) / 2
            : values[values.Length / 2];
    }
    public Variant Min(Variant[] values) => values.Select(v => v.IsReal).Min();
    public double PointDirection(double x1, double y1, double x2, double y2) => Math.Atan2(y2 - y1, x2 - x1) / Math.PI * 180;
    public double PointDistance(double x1, double y1, double x2, double y2) => Math.Sqrt(Sqr(x2 - x1) + Sqr(y2 - y1));
    public double PointDistance3d(double x1, double y1, double z1, double x2, double y2, double z2) => Math.Sqrt(Sqr(x2 - x1) + Sqr(y2 - y1) + Sqr(z2 - z1));
    public double Power(double x, double n) => Math.Pow(x, n);
    public double RadToDeg(double x) => x * 180 / Math.PI;
    public double Random(double max) => random.NextDouble() * max;
    public int RandomGetSeed() => randomSeed;
    public void Randomize()
    {
        randomSeed = new Random().Next();
        random = new Random(randomSeed);
    }
    public double RandomRange(int x1, int x2) => random.Next(x1, x2);
    public void RandomSetSeed(int seed)
    {
        randomSeed = seed;
        random = new Random(randomSeed);
    }
    public double Round(double value) => Math.Round(value);
    public double Sign(double value) => Math.Sign(value);
    public double Sin(double r) => Math.Sin(r);
    public double Sqr(double value) => value * value;
    public double Sqrt(double value) => Math.Sqrt(value);
    public double Tan(double r) => Math.Tan(r);
}