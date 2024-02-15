using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;
public interface IRealFunctions
{
    //
    // Intruduced in v1.1:
    //

    #region Deprecated Functions
    //
    // These were replaced with varargs versions in 5.3a:
    //

    // V1.1
    [Gml("min", v11, v52)]
    double Min(double x, double y);

    [Gml("max", v11, v52)]
    double Max(double x, double y);

    // Introduced in v3.0
    [Gml("min3", v30, v52)]
    double Min3(double x, double y, double z);

    [Gml("max3", v30, v52)]
    double Max3(double x, double y, double z);
    #endregion

    //
    // Introduced in v1.1
    //

    [Gml("random", v11)]
    double Random(double x);

    [Gml("abs", v11)]
    double Abs(double x);

    [Gml("sign", v11)]
    double Sign(double x);

    [Gml("round", v11)]
    double Round(double x);

    [Gml("floor", v11)]
    double Floor(double x);

    [Gml("ceil", v11)]
    double Ceil(double x);

    [Gml("frac", v11)]
    double Frac(double x);

    [Gml("sqrt", v11)]
    double Sqrt(double x);

    [Gml("sqr", v11)]
    double Sqr(double x);

    [Gml("power", v11)]
    double Power(double x, double n);

    [Gml("exp", v11)]
    double Exp(double x);

    [Gml("ln", v11)]
    double Ln(double x);

    [Gml("log2", v11)]
    double Log2(double x);

    [Gml("log10", v11)]
    double Log10(double x);

    [Gml("logn", v11)]
    double Logn(double n, double x);

    [Gml("sin", v11)]
    double Sin(double x);

    [Gml("cos", v11)]
    double Cos(double x);

    [Gml("tan", v11)]
    double Tan(double x);

    //
    // Introduced in v2.0
    //
    
    [Gml("degtorad", v20)]
    double DegToRad(double x);

    [Gml("radtodeg", v20)]
    double RadToDeg(double x);

    //
    // Introduced in v3.0
    //

    [Gml("arcsin", v30)]
    double Arcsin(double x);

    [Gml("arccos", v30)]
    double Arccos(double x);

    [Gml("arctan", v30)]
    double Arctan(double x);

    [Gml("mean", v30)]
    double Mean(double x, double y);

    //
    // Introduced in v3.1
    //
    [Gml("point_distance", v32b)]
    double PointDistance(double x1, double y1, double x2, double y2);

    [Gml("point_direction", v32b)]
    double PointDirection(double x1, double y1, double x2, double y2);

    //
    // Introduced in v4.1
    //
    [Gml("is_real", v41)]
    bool IsReal(double val);

    [Gml("is_string", v41)]
    bool IsString(string val);

    //
    // Introduced in v5.0
    //
    [Gml("arctan2", v50)]
    double Arctan2(double y, double x);

    //
    // Introduced in v5.1
    //
    [Gml("lengthdir_x", v51)]
    double LengthdirX(double len, double dir);

    [Gml("lengthdir_y", v51)]
    double LengthdirY(double len, double dir);

    //
    // 5.3a
    //
    [Gml("min", v53a)]
    double Min(params double[] values);

    [Gml("max", v53a)]
    double Max(params double[] values);

    [Gml("mean", v53a)]
    double Mean(params double[] values);

    //
    // 6.1
    //
    [Gml("median", v61)]
    double Median(params double[] values);

    [Gml("choose", v61)]
    double Choose(params double[] values);

    //
    // 7.0
    //
    [Gml("randomize", v70)]
    void Randomize();

    [Gml("random_get_seed", v70)]
    void RandomGetSeed();

    [Gml("random_set_seed", v70)]
    void RandomSetSeed(int seed);

    //
    // 8.0
    //
    [Gml("irandom_range", v80)]
    int IrandomRange(int x1, int x2);

    [Gml("irandom", v80)]
    int Irandom(int x);

    [Gml("random_range", v80)]
    double RandomRange(double x1, double x2);
}
