using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IRoomFunctions
{
    #region Deprecated Functions
    [Gml("goto_room", v11, v33)]
    void GotoRoom(int numb);

    [Gml("end_game", v11, v33)]
    void EndGame();
    
    [Gml("set_gamespeed", v11, v33)]
    void SetGamespeed(int numb);
    #endregion
}
