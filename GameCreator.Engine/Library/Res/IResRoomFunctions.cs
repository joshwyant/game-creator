using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IResRoomFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // Introduced in v4.3c
    //
    [Gml("room_exists", v43c)]
    bool RoomExists(int ind);

    [Gml("room_get_name", v43c)]
    string RoomGetName(int ind);
}
