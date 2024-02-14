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
    [Gml("sound", v11, v14)]
    void Sound(int numb);

    [Gml("show_highscore", v11, v14)]
    void ShowHighscore(int numb);

    [Gml("write", v11, v20)]
    void Write(int ind, double x);

    [Gml("read", v11, v20)]
    double Read(int ind);

    [Gml("goto_room", v11, v33)]
    void GotoRoom(int numb);

    [Gml("create", v11, v33)]
    void Create(double x, double y, int obj);

    [Gml("change", v11, v33)]
    void Change(int obj1, int obj2);

    [Gml("change_at", v11, v33)]
    void ChangeAt(double x, double y, int obj);

    [Gml("destroy", v11, v33)]
    void Destroy(int obj);

    [Gml("destroy_at", v11, v33)]
    void DestroyAt(double x, double y);

    [Gml("is_free", v11, v33)]
    bool IsFree(double x, double y);

    [Gml("is_empty", v11, v33)]
    bool IsEmpty(double x, double y);

    [Gml("is_meeting", v11, v33)]
    bool IsMeeting(double x, double y, int obj);

    [Gml("number", v11, v33)]
    int Number(int obj);

    [Gml("move_random", v11, v33)]
    void MoveRandom(int obj);

    [Gml("end_game", v11, v33)]
    void EndGame();

    [Gml("redraw", v11, v33)]
    void Redraw();

    [Gml("set_gamespeed", v11, v33)]
    void SetGamespeed(int numb);

    [Gml("min", v11, v52)]
    double Min(double x, double y);

    [Gml("max", v11, v52)]
    double Max(double x, double y);

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
