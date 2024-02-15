using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IRoomFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v1.0
    //
    [Gml("goto_room", v11, v33)]
    void GotoRoom(int numb);

    [Gml("end_game", v11, v33)]
    void EndGame();
    
    [Gml("set_gamespeed", v11, v33)]
    void SetGamespeed(int numb);

    //
    // Introduced in v3.1
    //
    [Gml("load_game", v31, v33)]
    void LoadGame(string str);

    [Gml("save_game", v31, v33)]
    void SaveGame(string str);

    [Gml("find_room", v31, v33)]
    void FindRoom(string str);
    #endregion
}
