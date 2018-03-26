using System.Collections.Generic;
using GameCreator.Resources.Api;

namespace GameCreator.Projects.GMFiles
{
    partial class GmFileReader
    {
        List<ActionEntry> getActions()
        {
            var actions = new List<ActionEntry>();

            var version = getInt();

            for (int count = getInt(), i = 0; i < count; i++)
            {
                var action = new ActionEntry();
                actions.Add(action);

                version = getInt();

                action.LibraryId = getInt();
                action.ActionId = getInt();
                action.Kind = (ActionKind)getInt();
                action.MayBeRelative = getBool();
                action.IsQuestion = getBool();
                action.AppliesToSomething = getBool();
                action.Type = (ActionExecutionType)getInt();
                action.FunctionName = getString();
                action.Code = getString();
                action.ArgumentsUsed = getInt();
                action.Arguments = new List<ActionArgument>(8);
                for (int argc = getInt(), j = 0; j < argc; j++)
                {
                    action.Arguments.Add(new ActionArgument((ActionArgumentType)getInt()));
                }
                action.AppliesToObjectIndex = getInt();
                action.Relative = getBool();
                for (int argc = getInt(), j = 0; j < argc; j++)
                {
                    var arg = action.Arguments[j];
                    arg.Value = getString();
                    action.Arguments[j] = arg; // Write it back since it's a struct
                }
                action.Not = getBool();
            }

            return actions;
        }
    }
}
