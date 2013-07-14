using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class EventExtensions
    {
        // skip an action or action block
        static void Skip(this Event e, ref int index)
        {
            int block = 0;
            do
            {
            tryagain:
                if (index < e.Actions.Count)
                {
                    switch (e.Actions[index].Definition.Kind)
                    {
                        case ActionKind.BeginGroup:
                            block++;
                            break;
                        case ActionKind.EndGroup:
                            block--;
                            break;
                        case ActionKind.Label:
                        case ActionKind.Placeholder:
                        case ActionKind.Separator:
                            index++;
                            goto tryagain;
                        case ActionKind.Repeat:
                        case ActionKind.Normal:
                            if (e.Actions[index].Definition.Kind == ActionKind.Repeat || e.Actions[index].Definition.IsQuestion)
                            {
                                index++;
                                e.Skip(ref index);
                                continue;
                            }
                            break;
                    }
                    index++;
                }
            } while (index < e.Actions.Count && block > 0);
        }
        // Executes an action or block of actions.
        // index is updated with the next action number.
        // return value indicates whether we need to exit the event (value returned == true).
        // That's why when calling ExecSingle() recursively we use 'if (ExecSingle(ref index)) return true;'
        static bool ExecSingle(this Event e, ref int index)
        {
            if (index >= e.Actions.Count)
                return true;
            switch (e.Actions[index].Definition.Kind)
            {
                case ActionKind.BeginGroup:
                    index++;
                    while (index < e.Actions.Count && e.Actions[index].Definition.Kind != ActionKind.EndGroup)
                        if (e.ExecSingle(ref index)) return true;
                    if (index < e.Actions.Count && e.Actions[index].Definition.Kind == ActionKind.EndGroup)
                        index++;
                    break;
                case ActionKind.Code:
                case ActionKind.Normal:
                case ActionKind.Variable:
                    // Execute the action, and if it returns false, skip the next group of actions, because it was a question and tested false.
                    bool question = e.Actions[index].Definition.IsQuestion;
                    bool @else = !e.Actions[index].Execute(); // Action.Execute() returns whether to execute the immediate next action or action group.
                    index++;
                    if (question)
                    {
                        if (@else)
                            e.Skip(ref index);
                        else
                        {
                            if (e.ExecSingle(ref index)) return true;
                        }
                        // question, else
                        if (question && index < e.Actions.Count && e.Actions[index].Definition.Kind == ActionKind.Else)
                        {
                            index++;
                            if (@else)
                            {
                                if (e.ExecSingle(ref index)) return true;
                            }
                            else
                                e.Skip(ref index);
                        }
                    }
                    break;
                case ActionKind.Exit:
                    // index++; // not needed
                    return true; // exit the event
                case ActionKind.Repeat:
                    int val = (int)Math.Round(Interpreter.Eval(e.Actions[index].Arguments[0]).Real);
                    int n = ++index;
                    while (val-- > 0)
                    {
                        index = n; // go back to the action to repeat it
                        if (e.ExecSingle(ref index)) return true;
                    }
                    break;
                // This action misplaced or something. skip over it.
                default:
                    index++;
                    break;
            }
            return false;
        }

        // Execute the whole list of actions.
        public static void Execute(this Event e)
        {
            var i = 0;

            while (i < e.Actions.Count && !ExecSingle(e, ref i)) /**/;
        }
    }
}
