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

    //
    // Introduced in v4.0
    //

    [Gml("room_goto", v40)]
    void RoomGoto(double numb);

    [Gml("room_goto_previous", v40)]
    void RoomGotoPrevious();

    [Gml("room_goto_next", v40)]
    void RoomGotoNext();

    [Gml("room_restart", v40)]
    void RoomRestart();

    [Gml("room_previous", v40)]
    void RoomPrevious(double numb);

    [Gml("room_next", v40)]
    void RoomNext(double numb);

    [Gml("game_end", v40)]
    void GameEnd();

    [Gml("game_restart", v40)]
    void GameRestart();

    [Gml("game_save", v40)]
    void GameSave(string @string);

    [Gml("game_load", v40)]
    void GameLoad(string @string);
}
