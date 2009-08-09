using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    class With : Stmt
    {
        Expr expr; Stmt stmt;
        public With(Expr e, Stmt s, int l, int c) : base(l, c) { expr = e; stmt = s; }
        protected override void run()
        {
            Value v = expr.Eval();
            if (!v.IsReal) Error("Object id expected");
            long instance = (long)Math.Round(v.Real);
            Env c = Env.Current;
            Env o = Env.Other;
            switch (instance)
            {
                case Env.self:
                    Env.Other = c;
                    break;
                case Env.other:
                    if (Env.Other == null) return;
                    Env.Current = Env.Other;
                    Env.Other = c;
                    break;
                case Env.all:
                    Env.Other = c;
                    foreach (long l in Env.Instances.Keys)
                    {
                        Env.Current = Env.Instances[l];
                        switch (Exec(stmt, FlowType.Continue|FlowType.Break))
                        {
                            case FlowType.None:
                            case FlowType.Continue:
                                break;
                            default:
                                Env.Current = c;
                                Env.Other = o;
                                return;
                        }
                    }
                    Env.Current = c;
                    Env.Other = o;
                    return;
                case Env.noone:
                    return;
                case Env.global:
                    Error("Cannot use global in a with statement.");
                    return;
                default:
                    if (Env.Instances.ContainsKey(instance))
                    {
                        Env.Current = Env.Instances[instance];
                        Env.Other = c;
                    }
                    else
                    {
                        Env.Other = c;
                        foreach (long l in Env.Instances.Keys)
                        {
                            if ((long)Env.GetVar(l, "object_index").Real == instance)
                            {
                                Env.Current = Env.Instances[l];
                                switch (Exec(stmt, FlowType.Continue|FlowType.Break))
                                {
                                    case FlowType.None:
                                    case FlowType.Continue:
                                        break;
                                    default:
                                        Env.Current = c;
                                        Env.Other = o;
                                        return;
                                }
                            }
                        }
                        Env.Current = c;
                        Env.Other = o;
                        return;
                    }
                    break;
            }
            Exec(stmt, FlowType.Break | FlowType.Continue);
        }
    }
}
