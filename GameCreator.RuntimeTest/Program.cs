using GameCreator.Runtime;

namespace GameCreator.RuntimeTest
{
    static class Program
    {
        static void Main()
        {
            // Initialize the runtime engine
            Game.Init();
            // Define action libraries
            ActionLibrary.Define(1).DefineAction(100, ActionKind.Normal, ActionExecutionType.Function, false, "action_create_object", string.Empty, new ActionArgumentType[] { ActionArgumentType.Object, ActionArgumentType.Expression, ActionArgumentType.Expression });
            ActionLibrary.Define(1).DefineAction(101, ActionKind.Code, ActionExecutionType.Function, false, "execute_string", string.Empty, new ActionArgumentType[] { ActionArgumentType.String });
            ActionLibrary.Define(1).DefineAction(102, ActionKind.Normal, ActionExecutionType.Function, false, "show_message", string.Empty, new ActionArgumentType[] { ActionArgumentType.String });
            ActionLibrary.Define(1).DefineAction(103, ActionKind.Normal, ActionExecutionType.Function, false, "action_move", string.Empty, new ActionArgumentType[] { ActionArgumentType.String, ActionArgumentType.Expression });
            // Define scripts
            Script.Define("scr_main", 0, "instance_create(0,0,0)");
            // Define objects
            Object.Define("object0", 0).DefineEvent((int)EventType.Create, 0).DefineAction(1, 100, new string[] { "1", "0", "0" }, -1, false, false);
            Event ev = Object.Define("object1", 1).DefineEvent((int)EventType.Create, 0);
            ev.DefineAction(1, 103, new string[] { "000000001", "4" }, -1, false, false);
            ev.DefineAction(1, 101, new string[] { "show_message(string(hspeed))" }, -1, false, false);
            // Define rooms
            Room.Define("room0", 0).CreationCode = "scr_main()";
            // Run the game
            Game.Run();
        }
    }
}
