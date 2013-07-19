using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class ActionExtensions
    {        
        // return value indicates whether to execute the next action (or group of actions).
        // only returns false if the action is a question and the action tests false.
        // Execute() is only called when the action type is Normal, Code, or Variable.
        public static bool Execute(this Action action)
        {
            // Get a list of affected instances for this action
            IEnumerable<Instance> instances;
            switch (action.AppliesTo)
            {
                case (int)InstanceTarget.Self:
                    instances = new[] { ExecutionContext.Current };
                    break;
                case (int)InstanceTarget.Other:
                    instances = new [] { ExecutionContext.Other };
                    break;
                default:
                    instances = from inst in ExecutionContext.Instances.Values
                                where inst.Context.Objects[inst.ObjectIndex].DescendsFrom(action.AppliesTo)
                                select inst;
                    break;
            }

            bool returned = !action.Not;
            ExecutionContext.argument_relative.value = action.Relative;
            var c = ExecutionContext.Current;
            var o = ExecutionContext.Other;
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
                        using (new ExecutionScope())
                        {
                            ExecutionContext.Returned = default(Value);
                            action.ExecuteCode();
                            if (ExecutionContext.Returned == action.Not)
                                returned = action.Not;
                            break;
                        }
                    case ActionKind.Normal:
                        Value[] args = new Value[action.Arguments.Length];
                        // Evaluate the arguments
                        for (int i = 0; i < args.Length; i++)
                        {
                            switch (action.Definition.Arguments[i])
                            {
                                case ActionArgumentType.Expression:
                                    args[i] = Interpreter.Eval(ExecutionContext.Current, action.Arguments[i]);
                                    break;
                                case ActionArgumentType.String:
                                case ActionArgumentType.FontString:
                                    args[i] = new Value(action.Arguments[i]);
                                    break;
                                case ActionArgumentType.Both:
                                    args[i] = action.Arguments[i].StartsWith("\"") 
                                        || action.Arguments[i].StartsWith("\'") 
                                        ? Interpreter.Eval(ExecutionContext.Current, action.Arguments[i]) 
                                        : new Value(action.Arguments[i]);
                                    break;
                                default:
                                    args[i] = new Value(double.Parse(action.Arguments[i]));
                                    break;
                            }
                        }
                        switch (action.Definition.ExecutionType)
                        {
                            case ActionExecutionType.Code:
                                ExecutionContext.Returned = default(Value);
                                using (new ExecutionScope(args))
                                {
                                    action.ExecuteCode();
                                    if (ExecutionContext.Returned == action.Not)
                                        returned = action.Not;
                                    break;
                                }
                            case ActionExecutionType.Function:
                                if (Interpreter.ExecuteFunction(action.Definition.FunctionName, args) == action.Not) returned = action.Not;
                                break;
                        }
                        break;
                }
                if (returned == action.Not) break;
            }
            ExecutionContext.Current = c;
            ExecutionContext.Other = o;
            ExecutionContext.argument_relative.value = false;
            return action.Definition.IsQuestion ? action.Not ? !returned : returned : true;
        }
    }
}
