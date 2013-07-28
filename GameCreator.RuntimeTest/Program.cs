using GameCreator.Framework;
using GameCreator.Runtime.Game;
using GameCreator.Framework.Gml.Interpreter;
using GameCreator.Runtime.Game.Interpreted;
using GameCreator.Runtime.Game.Jited;

namespace GameCreator.RuntimeTest
{
    static class Program
    {
        static void Main()
        {
            JitedGame.Initialize();

            var context = LibraryContext.Current;
            var resources = context.Resources;
            var lib = context.GetActionLibrary(1);

            // Define action libraries
            lib.DefineAction(100, ActionKind.Normal, ActionExecutionType.Function, false, "action_create_object", string.Empty, new ActionArgumentType[] { ActionArgumentType.Object, ActionArgumentType.Expression, ActionArgumentType.Expression });
            lib.DefineAction(101, ActionKind.Code, ActionExecutionType.Function, false, "execute_string", string.Empty, new ActionArgumentType[] { ActionArgumentType.String });
            lib.DefineAction(102, ActionKind.Normal, ActionExecutionType.Function, false, "show_message", string.Empty, new ActionArgumentType[] { ActionArgumentType.String });
            lib.DefineAction(103, ActionKind.Normal, ActionExecutionType.Function, false, "action_move", string.Empty, new ActionArgumentType[] { ActionArgumentType.String, ActionArgumentType.Expression });
            // Define scripts
            resources.Scripts.Define("scr_main", "instance_create(0,0,0)");
            // Define objects
            resources.Objects.Define().DefineEvent((int)EventType.Create, 0).DefineAction(1, 100, new string[] { "1", "0", "0" }, -1, false, false);
            Event ev = context.Resources.Objects.Define().DefineEvent((int)EventType.Create, 0);
            ev.DefineAction(1, 103, new string[] { "000000001", "4" }, -1, false, false);
            ev.DefineAction(1, 101, new string[] { "show_message(string(hspeed))" }, -1, false, false);
            // Define rooms
            resources.Rooms.Define().CreationCode = "if (0.5) switch (4) { case 2: case 3: default: case 5: show_message(string(2 << 4));} game_end()";
            // Run the game
            JitedGame.Run();
        }
    }
}
