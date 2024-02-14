using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
random(x)	1.1
abs(x)	1.1
sign(x)	1.1
round(x)	1.1
floor(x)	1.1
ceil(x)	1.1
frac(x)	1.1
sqrt(x)	1.1
sqr(x)	1.1
power(x, n)	1.1
exp(x)	1.1
ln(x)	1.1
log2(x)	1.1
log10(x)	1.1
logn(n, x)	1.1
sin(x)	1.1
cos(x)	1.1
tan(x)	1.1
set_score(numb)	1.1
sleep(numb)	1.1

*/

public interface IGMv11Functions
{
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

    [Gml("set_score", v11)]
    void SetScore(double numb);

    [Gml("sleep", v11)]
    void Sleep(double numb);
}
