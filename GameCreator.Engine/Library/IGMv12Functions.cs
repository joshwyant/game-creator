using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:

*/

public interface IGMv12Functions
{
    [Gml("nothing_at", v12, v33)]
    bool NothingAt(double x, double y);

    [Gml("object_at", v12, v33)]
    bool ObjectAt(double x, double y, int obj);

    [Gml("show_cursor", v12, v33)]
    void ShowCursor(bool show);
}
