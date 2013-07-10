using System;
using System.Collections.Generic;
using GameCreator.Framework.Gml;

namespace GameCreator.Framework
{
    // Holds a list of actions in either an event or a timeline moment
    public class Event
    {
        EventType EventType { get; set; }
        int EventNumber { get; set; }
        List<Action> Actions { get; set; }
        internal Event(EventType type, int num)
        {
            EventType = type;
            EventNumber = num;
            Actions = new List<Action>();
        }
        public void DefineAction(int libid, int actionid, string[] args, int appliesto, bool relative, bool not)
        {
            Actions.Add(new Action(libid, actionid, args, appliesto, relative, not));
        }
        // skip an action or action block
        void Skip(ref int index)
        {
            int block = 0;
            do
            {
            tryagain:
                if (index < Actions.Count)
                {
                    switch (Actions[index].Definition.Kind)
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
                            if (Actions[index].Definition.Kind == ActionKind.Repeat || Actions[index].Definition.IsQuestion)
                            {
                                index++;
                                Skip(ref index);
                                continue;
                            }
                            break;
                    }
                    index++;
                }
            } while (index < Actions.Count && block > 0);
        }
        // Executes an action or block of actions.
        // index is updated with the next action number.
        // return value indicates whether we need to exit the event (value returned == true).
        // That's why when calling ExecSingle() recursively we use 'if (ExecSingle(ref index)) return true;'
        bool ExecSingle(ref int index)
        {
            if (index >= Actions.Count)
                return true;
            switch (Actions[index].Definition.Kind)
            {
                case ActionKind.BeginGroup:
                    index++;
                    while (index < Actions.Count && Actions[index].Definition.Kind != ActionKind.EndGroup)
                        if (ExecSingle(ref index)) return true;
                    if (index < Actions.Count && Actions[index].Definition.Kind == ActionKind.EndGroup)
                        index++;
                    break;
                case ActionKind.Code:
                case ActionKind.Normal:
                case ActionKind.Variable:
                    // Execute the action, and if it returns false, skip the next group of actions, because it was a question and tested false.
                    bool question = Actions[index].Definition.IsQuestion;
                    bool @else = !Actions[index].Execute(); // Action.Execute() returns whether to execute the immediate next action or action group.
                    index++;
                    if (question)
                    {
                        if (@else)
                            Skip(ref index);
                        else
                        {
                            if (ExecSingle(ref index)) return true;
                        }
                        // question, else
                        if (question && index < Actions.Count && Actions[index].Definition.Kind == ActionKind.Else)
                        {
                            index++;
                            if (@else)
                            {
                                if (ExecSingle(ref index)) return true;
                            }
                            else
                                Skip(ref index);
                        }
                    }
                    break;
                case ActionKind.Exit:
                    // index++; // not needed
                    return true; // exit the event
                case ActionKind.Repeat:
                    int val = (int)Math.Round(Parser.Evaluate(Actions[index].Arguments[0]).Real);
                    int n = ++index;
                    while (val-- > 0)
                    {
                        index = n; // go back to the action to repeat it
                        if (ExecSingle(ref index)) return true;
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
        internal void Execute() { for (int i = 0; i < Actions.Count && !ExecSingle(ref i); ) ; }
    }
}