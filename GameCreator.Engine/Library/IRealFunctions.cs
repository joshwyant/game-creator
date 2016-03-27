using GameCreator.Engine.Api;
using GameCreator.Runtime.Api;

namespace GameCreator.Engine.Library
{
    public interface IRealFunctions
    {
        [Gml("random")]
        double Random(double max);
        
        [Gml("random_range")]
        double RandomRange(int x1, int x2);
        
        [Gml("irandom")]
        int IRandom(double max);
        
        [Gml("irandom_range")]
        int IRandomRange(double min, double max);
        
        [Gml("random_set_seed")]
        void RandomSetSeed(int seed);
        
        [Gml("random_get_seed")]
        int RandomGetSeed();
        
        [Gml("randomize")]
        int Randomize();
        
        [Gml("choose")]
        Variant Choose(Variant[] args);
        
        [Gml("abs")]
        double Abs(double value);
        
        [Gml("sign")]
        double Sign(double value);
        
        [Gml("round")]
        double Round(double value);
        
        [Gml("floor")]
        double Floor(double value);
        
        [Gml("ceil")]
        double Ceil(double value);
        
        [Gml("frac")]
        double Frac(double value);
        
        [Gml("sqrt")]
        double Sqrt(double value);
        
        [Gml("sqr")]
        double Sqr(double value);
        
        [Gml("power")]
        double Power(double x, double n);
        
        [Gml("exp")]
        double Exp(double x);
        
        [Gml("ln")]
        double Ln(double x);
        
        [Gml("log2")]
        double Log2(double x);
        
        [Gml("log10")]
        double Log10(double x);
        
        [Gml("logn")]
        double LogN(double n, double x);
        
        [Gml("sin")]
        double Sin(double r);
        
        [Gml("cos")]
        double Cos(double r);
        
        [Gml("tan")]
        double Tan(double r);
        
        [Gml("arcsin")]
        double ArcSin(double x);
        
        [Gml("arccos")]
        double ArcCos(double x);
        
        [Gml("arctan")]
        double ArcTan(double x);
        
        [Gml("arctan2")]
        double ArcTan2(double y, double x);
        
        [Gml("degtorad")]
        double DegToRad(double x);
        
        [Gml("radtodeg")]
        double RadToDeg(double x);
        
        [Gml("min")]
        Variant Min(Variant[] values);
        
        [Gml("max")]
        Variant Max(Variant[] values);
        
        [Gml("mean")]
        double Mean(double[] values);
        
        [Gml("median")]
        double Median(double[] values);
        
        [Gml("point_distance")]
        double PointDistance(double x1, double y1, double x2, double y2);
        
        [Gml("point_distance_3d")]
        double PointDistance3d(double x1, double y1, double z1, double x2, double y2, double z2);
        
        [Gml("point_direction")]
        double PointDirection(double x1, double y1, double x2, double y2);
        
        [Gml("lengthdir_x")]
        double LengthDirX(double length, double dir);
        
        [Gml("lengthdir_y")]
        double LengthDirY(double length, double dir);
        
        [Gml("dot_product")]
        double DotProduct(double x1, double y1, double x2, double y2);
        
        [Gml("dot_product3d")]
        double DotProduct3d(double x1, double y1, double z1, double x2, double y2, double z2);
        
        [Gml("is_real")]
        bool IsReal(Variant v);
        
        [Gml("is_string")]
        bool IsString(Variant v);
    }
}