using App.Contracts;
using App.Resources;
using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace GameCreator.Projects
{
    partial class GmFileProjectReader
    {
        List<IAppAction> getActions()
        {
            var actions = new List<IAppAction>();

            int version = getInt();

            for (int count = getInt(), i = 0; i < count; i++)
            {
                if (getInt() != 0)
                {
                    var action = new AppAction();
                    actions.Add(action);

                    version = getInt();

                    action.LibraryId = getInt();
                    action.ActionId = getInt();
                    action.Kind = (ActionKind)getInt();
                    action.MayBeRelative = getBool();
                    action.IsQuestion = getBool();
                    action.AppliesToSomething = getBool();
                    action.Type = (ActionType)getInt();
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
            }

            return actions;
        }
    }
}
