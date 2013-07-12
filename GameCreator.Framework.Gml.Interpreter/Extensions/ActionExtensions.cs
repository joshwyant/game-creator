using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class ActionExtensions
    {        // return value indicates whether to execute the next action (or group of actions).
        // only returns false if the action is a question and the action tests false.
        // Execute() is only called when the action type is Normal, Code, or Variable.
        public bool Execute(this Action action)
        {
            System.Collections.Generic.List<Instance> instances = new System.Collections.Generic.List<Instance>(1);
            switch (action.AppliesTo)
            {
                case (int)ActionScope.Self:
                    instances.Add(ExecutionContext.Current);
                    break;
                case (int)ActionScope.Other:
                    instances.Add(ExecutionContext.Other);
                    break;
                default:
                    foreach (Instance e in ExecutionContext.Instances.Values)
                    {
                        if (e.object_index.value == action.AppliesTo)
                            instances.Add(e);
                    }
                    break;
            }
            bool returned = !action.Not;
            ExecutionContext.argument_relative.value = action.Relative;
            Instance c = ExecutionContext.Current;
            Instance o = ExecutionContext.Other;
            foreach (Instance e in instances)
            {
                if (e != c)
                {
                    ExecutionContext.Current = e;
                    ExecutionContext.Other = c;
                }
                switch (action.Definition.Kind)
                {
                    case ActionKind.Code:
                    case ActionKind.Variable:
                        ExecutionContext.Returned = new Value();
                        ExecutionContext.Enter();
                        action.Code.Run();
                        ExecutionContext.Leave();
                        if (ExecutionContext.Returned == Not) returned = Not;
                        break;
                    case ActionKind.Normal:
                        Value[] args = new Value[Arguments.Length];
                        // Evaluate the arguments
                        for (int i = 0; i < args.Length; i++)
                        {
                            switch (Definition.Arguments[i])
                            {
                                case ActionArgumentType.Expression:
                                    args[i] = Parser.Evaluate(ExecutionContext.Current, Arguments[i]);
                                    break;
                                case ActionArgumentType.String:
                                case ActionArgumentType.FontString:
                                    args[i] = new Value(Arguments[i]);
                                    break;
                                case ActionArgumentType.Both:
                                    args[i] = Arguments[i].StartsWith("\"") || Arguments[i].StartsWith("\'") ? Parser.Evaluate(ExecutionContext.Current, Arguments[i]) : new Value(Arguments[i]);
                                    break;
                                default:
                                    args[i] = new Value(double.Parse(Arguments[i]));
                                    break;
                            }
                        }
                        switch (Definition.ExecutionType)
                        {
                            case ActionExecutionType.Code:
                                ExecutionContext.Returned = new Value();
                                ExecutionContext.Enter();
                                ExecutionContext.SetArguments(args);
                                Definition.Code.Run();
                                ExecutionContext.Leave();
                                if (ExecutionContext.Returned == Not) returned = Not;
                                break;
                            case ActionExecutionType.Function:
                                if (ExecutionContext.ExecuteFunction(Definition.FunctionName, args) == Not) returned = Not;
                                break;
                        }
                        break;
                }
                if (returned == Not) break;
            }
            ExecutionContext.Current = c;
            ExecutionContext.Other = o;
            ExecutionContext.argument_relative.value = false;
            return Definition.IsQuestion ? Not ? !returned : returned : true;
        }
    }
}
