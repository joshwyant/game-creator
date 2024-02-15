using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IStringFunctions
{
    //
    // Introduced in v1.4
    //
    [Gml("chr", v14)]
    string Chr(double val);

    [Gml("ord", v14)]
    double Ord(string val);

    [Gml("string", v14)]
    string String(double x);
}
