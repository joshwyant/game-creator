using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:

Deprecated functions:
nothing_at(x, y)	1.2	3.3
object_at(x, y, obj)	1.2	3.3
show_cursor(show)	1.2	3.3

*/

public interface IGMv12Functions
{
    #region Deprecated Functions
    [Gml("nothing_at", v12, v33)]
    bool NothingAt(double x, double y);

    [Gml("object_at", v12, v33)]
    bool ObjectAt(double x, double y, int obj);

    [Gml("show_cursor", v12, v33)]
    void ShowCursor(bool show);
    #endregion
}
