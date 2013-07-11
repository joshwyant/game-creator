using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class With : Statement
    {
        Expression expr; Statement stmt;
        public With(Expression e, Statement s, int l, int c) : base(l, c) { expr = e; stmt = s; }
        protected override void run()
        {
            Value v = expr.Eval();
            if (!v.IsReal) Error("Object id expected");
            int instance = v;
            Instance c = ExecutionContext.Current;
            Instance o = ExecutionContext.Other;
            switch (instance)
            {
                case ExecutionContext.self:
                    ExecutionContext.Other = c;
                    break;
                case ExecutionContext.other:
                    if (ExecutionContext.Other == null) return;
                    ExecutionContext.Current = ExecutionContext.Other;
                    ExecutionContext.Other = c;
                    break;
                case ExecutionContext.all:
                    ExecutionContext.Other = c;
                    foreach (int i in ExecutionContext.Instances.Keys)
                    {
                        ExecutionContext.Current = ExecutionContext.Instances[i];
                        switch (Exec(stmt, FlowType.Continue|FlowType.Break))
                        {
                            case FlowType.None:
                            case FlowType.Continue:
                                break;
                            default:
                                ExecutionContext.Current = c;
                                ExecutionContext.Other = o;
                                return;
                        }
                    }
                    ExecutionContext.Current = c;
                    ExecutionContext.Other = o;
                    return;
                case ExecutionContext.noone:
                    return;
                case ExecutionContext.global:
                    Error("Cannot use global in a with statement.");
                    return;
                default:
                    if (ExecutionContext.Instances.ContainsKey(instance))
                    {
                        ExecutionContext.Current = ExecutionContext.Instances[instance];
                        ExecutionContext.Other = c;
                    }
                    else
                    {
                        ExecutionContext.Other = c;
                        foreach (int i in ExecutionContext.Instances.Keys)
                        {
                            if (ExecutionContext.GetVar(i, "object_index") == instance)
                            {
                                ExecutionContext.Current = ExecutionContext.Instances[i];
                                switch (Exec(stmt, FlowType.Continue|FlowType.Break))
                                {
                                    case FlowType.None:
                                    case FlowType.Continue:
                                        break;
                                    default:
                                        ExecutionContext.Current = c;
                                        ExecutionContext.Other = o;
                                        return;
                                }
                            }
                        }
                        ExecutionContext.Current = c;
                        ExecutionContext.Other = o;
                        return;
                    }
                    break;
            }
            Exec(stmt, FlowType.Break | FlowType.Continue);
            // Hey!!
            // It looks like I didn't reset the previous instance in Env.Current and Env.Other?
            // like:
            // Env.Current = c;
            // Env.Other = o;
            // I'll put it here and see if that doesn't mess everything up :)
            ExecutionContext.Current = c;
            ExecutionContext.Other = o;
        }

        public override StatementKind Kind
        {
            get { return StatementKind.With; }
        }
    }
}
