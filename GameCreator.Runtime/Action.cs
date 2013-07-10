using GameCreator.Framework.Gml;

namespace GameCreator.Framework
{
    class Action
    {
        public ActionDefinition Definition { get; private set; }
        public string[] Arguments { get; private set; }
        int m_appliesto;
        bool m_relative;
        bool m_not;
        CodeUnit cu;
        public Action(int libid, int id, string[] args, int appliesto, bool relative, bool not)
        {
            Definition = ActionLibrary.GetAction(libid, id);
            Arguments = args;
            m_appliesto = appliesto;
            m_relative = relative;
            m_not = not;
            if (Definition.Kind == ActionKind.Code)
                cu = new CodeUnit(Arguments[0]);
            else if (Definition.Kind == ActionKind.Variable)
                // will be compiled after first time run
                cu = new CodeUnit(string.Format(m_relative ? "{0} += {1}" : "{0} = {1}", Arguments[0], Arguments[1]));
        }
        // return value indicates whether to execute the next action (or group of actions).
        // only returns false if the action is a question and the action tests false.
        // Execute() is only called when the action type is Normal, Code, or Variable.
        public bool Execute()
        {
            System.Collections.Generic.List<Instance> instances = new System.Collections.Generic.List<Instance>(1);
            switch (m_appliesto)
            {
                case Env.self:
                    instances.Add(Env.Current);
                    break;
                case Env.other:
                    instances.Add(Env.Other);
                    break;
                default:
                    foreach (Instance e in Env.Instances.Values)
                    {
                        if (e.object_index.value == m_appliesto)
                            instances.Add(e);
                    }
                    break;
            }
            bool returned = !m_not;
            Env.argument_relative.value = m_relative;
            Instance c = Env.Current;
            Instance o = Env.Other;
            foreach (Instance e in instances)
            {
                if (e != c)
                {
                    Env.Current = e;
                    Env.Other = c;
                }
                switch (Definition.Kind)
                {
                    case ActionKind.Code:
                    case ActionKind.Variable:
                        Env.Returned = new Value();
                        Env.Enter();
                        cu.Run();
                        Env.Leave();
                        if (Env.Returned == m_not) returned = m_not;
                        break;
                    case ActionKind.Normal:
                        Value[] args = new Value[Arguments.Length];
                        // Evaluate the arguments
                        for (int i = 0; i < args.Length; i++)
                        {
                            switch (Definition.Arguments[i])
                            {
                                case ActionArgumentType.Expression:
                                    args[i] = Parser.Evaluate(Env.Current, Arguments[i]);
                                    break;
                                case ActionArgumentType.String:
                                case ActionArgumentType.FontString:
                                    args[i] = new Value(Arguments[i]);
                                    break;
                                case ActionArgumentType.Both:
                                    args[i] = Arguments[i].StartsWith("\"") || Arguments[i].StartsWith("\'") ? Parser.Evaluate(Env.Current, Arguments[i]) : new Value(Arguments[i]);
                                    break;
                                default:
                                    args[i] = new Value(double.Parse(Arguments[i]));
                                    break;
                            }
                        }
                        switch (Definition.ExecutionType)
                        {
                            case ActionExecutionType.Code:
                                Env.Returned = new Value();
                                Env.Enter();
                                Env.SetArguments(args);
                                Definition.Code.Run();
                                Env.Leave();
                                if (Env.Returned == m_not) returned = m_not;
                                break;
                            case ActionExecutionType.Function:
                                if (Env.ExecuteFunction(Definition.FunctionName, args) == m_not) returned = m_not;
                                break;
                        }
                        break;
                }
                if (returned == m_not) break;
            }
            Env.Current = c;
            Env.Other = o;
            Env.argument_relative.value = false;
            return Definition.IsQuestion ? m_not ? !returned : returned : true;
        }
    }
}
