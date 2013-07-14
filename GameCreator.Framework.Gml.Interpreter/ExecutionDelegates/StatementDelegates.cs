using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    static class StatementDelegates
    {
        #region Assignments
        [Statement(Kind = StatementKind.Assignment)]
        public static void Assignment(Statement s)
        { ((Assignment)s).Lefthand.Set(((Assignment)s).Expression.Eval()); }

        [Statement(Kind = StatementKind.AndAssignment)]
        public static void AndAssignment(Statement s)
        { Assignment(s, (x, y) => (double)(Convert.ToInt64(x) & Convert.ToInt64(y))); }

        [Statement(Kind = StatementKind.OrAssignment)]
        public static void OrAssignment(Statement s)
        { Assignment(s, (x, y) => (double)(Convert.ToInt64(x) | Convert.ToInt64(y))); }

        [Statement(Kind = StatementKind.XorAssignment)]
        public static void XorAssignment(Statement s)
        { Assignment(s, (x, y) => (double)(Convert.ToInt64(x) ^ Convert.ToInt64(y))); }

        [Statement(Kind = StatementKind.SubtractionAssignment)]
        public static void SubtractionAssignment(Statement s)
        { Assignment(s, (x, y) => x - y); }

        [Statement(Kind = StatementKind.DivideAssignment)]
        public static void DivideAssignment(Statement s)
        {
            var a = (Assignment)s;

            var v1 = a.Lefthand.Eval();
            var v2 = a.Expression.Eval();

            if (v1.IsReal && v2.IsReal && v2.Real != 0.0)
                a.Lefthand.Set(v1 / v2);
        }

        [Statement(Kind = StatementKind.AdditionAssignment)]
        public static void AdditionAssignment(Statement s)
        {
            var a = (Assignment)s;

            var v1 = a.Lefthand.Eval();
            var v2 = a.Expression.Eval();

            if (v1.IsReal && v2.IsReal)
                a.Lefthand.Set(v1.Real + v2.Real);

            if (v1.IsString && v2.IsString)
                a.Lefthand.Set(v1.String + v2.String);
        }

        [Statement(Kind = StatementKind.MultiplyAssignment)]
        public static void MultiplyAssignment(Statement s)
        {
            var a = (Assignment)s;

            var v1 = a.Lefthand.Eval();
            var v2 = a.Expression.Eval();

            if (v1.IsReal && v2.IsReal)
                a.Lefthand.Set(v1.Real + v2.Real);
            else if (v1.IsReal && v2.IsString)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < (int)Math.Round(v1.Real); i++)
                    sb.Append(v2.String);
                a.Lefthand.Set(sb.ToString());
            }
        }
        #endregion

        #region Flow
        [Statement(Kind = StatementKind.Break)]
        public static void Break(Statement s)
        { Interpreter.ProgramFlow = FlowType.Break; }

        [Statement(Kind = StatementKind.Nop)]
        public static void Nop(Statement s) { }

        [Statement(Kind = StatementKind.Continue)]
        public static void Continue(Statement s)
        { Interpreter.ProgramFlow = FlowType.Continue; }

        [Statement(Kind = StatementKind.Exit)]
        public static void Exit(Statement s)
        { Interpreter.ProgramFlow = FlowType.Exit; }
        #endregion

        #region Switch
        [Statement(Kind = StatementKind.Switch)]
        public static void Switch(Statement s)
        {
            var block = (Switch)s;

            bool met = false;
            var v1 = block.Expression.Eval();

            foreach (Statement stmt in block.Statements)
            {
                if (stmt.Kind == StatementKind.Default)
                    met = true;
                else if (stmt.Kind == StatementKind.Case)
                {
                    if (!met) // we don't need to evaluate the case label expression if we are falling through
                    {
                        var v2 = ((Case)stmt).Expression.Eval();
                        if ((v1.IsReal && v2.IsReal && v1.Real == v2.Real) ||
                            (v1.IsString && v2.IsString && v1.String == v2.String))
                            met = true;
                    }
                }
                else if (met)
                {
                    if (Interpreter.Exec(stmt, FlowType.Break) != FlowType.None) return;
                }
            }
        }

        [Statement(Kind = StatementKind.Case)]
        public static void Case(Statement s)
        {
            // This will get run as a normal statement when not in a switch block, and will trigger the exception.
            // A switch block handles this statement specially.
            Error("Case statement only allowed inside switch statement.");
        }

        [Statement(Kind = StatementKind.Default)]
        public static void Default(Statement s)
        {
            // This will get run as a normal statement when not in a switch block, and will trigger the exception.
            // A switch block handles this statement specially.
            Error("Default statement only allowed inside switch statement.");
        }
        #endregion

        #region Calls
        [Statement(Kind = StatementKind.Call)]
        public static void Call(Statement s)
        {
            ((CallStatement)s).Call.Eval();
        }

        [Statement(Kind = StatementKind.Return)]
        public static void Return(Statement s)
        {
            ExecutionContext.Returned = ((Return)s).Expression.Eval();
            Interpreter.ProgramFlow = FlowType.Exit;
        }
        #endregion

        #region Others
        [Statement(Kind = StatementKind.Sequence)]
        public static void Sequence(Statement s)
        {
            var seq = (Sequence)s;

            if (Interpreter.Exec(seq.First) != FlowType.None) return;
            if (Interpreter.Exec(seq.Second) != FlowType.None) return;
        }

        [Statement(Kind = StatementKind.Globalvar)]
        public static void Globalvar(Statement s)
        {
            ExecutionContext.GlobalVars(((Globalvar)s).Variables);
        }

        [Statement(Kind = StatementKind.Var)]
        public static void Var(Statement s)
        {
            ExecutionContext.LocalVars(((Var)s).Variables);
        }
        #endregion

        #region Control
        [Statement(Kind = StatementKind.If)]
        public static void If(Statement s)
        {
            var stmt = (If)s;

            var v = stmt.Expression.Eval();

            if (!v.IsReal) 
                Error("Expression expected");

            if (v)
            {
                if (Interpreter.Exec(stmt.Body) != FlowType.None) return;
            }
            else
            {
                if (Interpreter.Exec(stmt.Else) != FlowType.None) return;
            }
        }

        [Statement(Kind = StatementKind.For)]
        public static void For(Statement s)
        {
            var stmt = (For)s;

            // Game Maker allows continues and breaks AFTER the initialization statment.
            if (Interpreter.Exec(stmt.Initializer) != FlowType.None) return;
        loop:
            var v = stmt.Test.Eval();

            if (!v.IsReal)
                Error("Expression expected");

            if (v <= 0.5) 
                return;

            if ((Interpreter.Exec(stmt.Iterator, FlowType.Continue | FlowType.Break) & ~FlowType.Continue) != FlowType.None) 
                return;

            if (Interpreter.Exec(stmt.Body) != FlowType.None) 
                return;

            goto loop;
        }

        [Statement(Kind = StatementKind.Do)]
        public static void Do(Statement s)
        {
            var stmt = (Do)s;

            Value v;
            do
            {
                if ((Interpreter.Exec(stmt.Body, FlowType.Continue | FlowType.Break) & ~FlowType.Continue) == FlowType.None)
                {
                    v = stmt.Expression.Eval();

                    if (!v.IsReal)
                        Error("Boolean expression expected");
                }
                else break;
            } while (v);
        }

        [Statement(Kind = StatementKind.With)]
        public static void With(Statement s)
        {
            var with = (With)s;

            var v = with.Instance.Eval();

            if (!v.IsReal)
                Error("Object id expected");

            var c = ExecutionContext.Current;
            var o = ExecutionContext.Other;

            int instance = v;
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
                        switch (Interpreter.Exec(with.Body, FlowType.Continue | FlowType.Break))
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
                                switch (Interpreter.Exec(with.Body, FlowType.Continue | FlowType.Break))
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
            Interpreter.Exec(with.Body, FlowType.Break | FlowType.Continue);

            // Restore current and other instances
            ExecutionContext.Current = c;
            ExecutionContext.Other = o;
        }

        [Statement(Kind = StatementKind.While)]
        public static void While(Statement s)
        {
            var w = (While)s;

            Value v = w.Expression.Eval();

            if (!v.IsReal)
                Error("Boolean expression expected");

            while (v)
            {
                if ((Interpreter.Exec(w.Body, FlowType.Break | FlowType.Continue) & ~FlowType.Continue) != FlowType.None)
                    return;

                v = w.Expression.Eval();

                if (!v.IsReal)
                    Error("Boolean expression expected");
            }
        }

        [Statement(Kind = StatementKind.Repeat)]
        public static void Repeat(Statement s)
        {
            var repeat = (Repeat)s;

            Value v = repeat.Expression.Eval();

            if (!v.IsReal)
                Error("Repeat count must be a number");

            int times = (int)Math.Round(v.Real);

            while (times > 0)
            {
                if ((Interpreter.Exec(repeat.Body, FlowType.Continue | FlowType.Break) & ~FlowType.Continue) != FlowType.None)
                    return;
                times--;
            }
        }
        #endregion

        #region Helpers
        static void Assignment(Statement s, Func<double, double, double> result)
        {
            var a = (Assignment)s;
            
            var v1 = a.Lefthand.Eval();
            var v2 = a.Expression.Eval();

            if (v1.IsReal && v2.IsReal)
                a.Lefthand.Set(result(v1, v2));
        }

        static void Error(string str)
        {
            throw new ProgramError(str, ErrorSeverity.Error, ExecutionContext.ExecutingStatement);
        }
        #endregion
    }
}
