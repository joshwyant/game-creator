using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
distance_to_point(x, y)	3.1
distance_to_object(obj)	3.1

*/

public interface IGMv31Functions
{
    [Gml("load_game", v31, v33)]
    void LoadGame(string str);

    [Gml("save_game", v31, v33)]
    void SaveGame(string str);

    [Gml("find_room", v31, v33)]
    void FindRoom(string str);

    [Gml("move_towards", v31, v33)]
    void MoveTowards(double x, double y);

    [Gml("get_joystick_xpos", v31, v33)]
    double GetJoystickXpos();

    [Gml("get_joystick_ypos", v31, v33)]
    double GetJoystickYpos();

    [Gml("get_joystick_zpos", v31, v33)]
    double GetJoystickZpos();
    
    [Gml("distance_to_point", v31)]
    double DistanceToPoint(double x, double y);

    [Gml("distance_to_object", v31)]
    double DistanceToObject(string obj);
}