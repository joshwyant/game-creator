using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Runtime;

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
                    if (Exec(stmt, FlowType.Break) != FlowType.None) return;
                }
            }
        }

        [Statement(Kind = StatementKind.Case)]
        public static void Case(Statement s)
        {
            // This will get run as a normal statement when not in a switch block, and will trigger the exception.
            // A switch block handles this statement specially.
            ThrowError(Error.Case);
        }

        [Statement(Kind = StatementKind.Default)]
        public static void Default(Statement s)
        {
            // This will get run as a normal statement when not in a switch block, and will trigger the exception.
            // A switch block handles this statement specially.
            ThrowError(Error.Default);
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
            Interpreter.Returned = ((Return)s).Expression.Eval();
            Interpreter.ProgramFlow = FlowType.Exit;
        }
        #endregion

        #region Others
        [Statement(Kind = StatementKind.Sequence)]
        public static void Sequence(Statement s)
        {
            var seq = (Sequence)s;

            if (Exec(seq.First) != FlowType.None) return;
            if (Exec(seq.Second) != FlowType.None) return;
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
                ThrowError(Error.ExpectedExpression);

            if (v)
            {
                if (Exec(stmt.Body) != FlowType.None) return;
            }
            else
            {
                if (Exec(stmt.Else) != FlowType.None) return;
            }
        }

        [Statement(Kind = StatementKind.For)]
        public static void For(Statement s)
        {
            var stmt = (For)s;

            // Game Maker allows continues and breaks AFTER the initialization statment.
            if (Exec(stmt.Initializer) != FlowType.None) return;
        loop:
            var v = stmt.Test.Eval();

            if (!v.IsReal)
                ThrowError(Error.ExpectedExpression);

            if (v <= 0.5) 
                return;

            if ((Exec(stmt.Iterator, FlowType.Continue | FlowType.Break) & ~FlowType.Continue) != FlowType.None) 
                return;

            if (Exec(stmt.Body) != FlowType.None) 
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
                if ((Exec(stmt.Body, FlowType.Continue | FlowType.Break) & ~FlowType.Continue) == FlowType.None)
                {
                    v = stmt.Expression.Eval();

                    if (!v.IsReal)
                        ThrowError(Error.ExpectedBooleanExpression);
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
                ThrowError(Error.ExpectedObjectId);

            var c = ExecutionContext.Current;
            var o = ExecutionContext.Other;

            int instance = v;
            switch ((InstanceTarget)instance)
            {
                case InstanceTarget.Self:
                    ExecutionContext.Other = c;
                    break;
                case InstanceTarget.Other:
                    if (ExecutionContext.Other == null) return;
                    ExecutionContext.Current = ExecutionContext.Other;
                    ExecutionContext.Other = c;
                    break;
                case InstanceTarget.All:
                    ExecutionContext.Other = c;
                    foreach (var i in ExecutionContext.Instances)
                    {
                        ExecutionContext.Current = i;
                        switch (Exec(with.Body, FlowType.Continue | FlowType.Break))
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
                case InstanceTarget.Noone:
                    return;
                case InstanceTarget.Global:
                    ThrowError(Error.GlobalWith);
                    return;
                default:
                    if (ExecutionContext.Instances.Any(e => e.id == instance))
                    {
                        ExecutionContext.Current = LibraryContext.Current.InstanceFactory.Instances[instance] as RuntimeInstance;
                        ExecutionContext.Other = c;
                    }
                    else
                    {
                        ExecutionContext.Other = c;
                        foreach (var i in ExecutionContext.Instances)
                        {
                            if (i.object_index == instance)
                            {
                                ExecutionContext.Current = i;
                                switch (Exec(with.Body, FlowType.Continue | FlowType.Break))
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
            Exec(with.Body, FlowType.Break | FlowType.Continue);

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
                ThrowError(Error.ExpectedBooleanExpression);

            while (v)
            {
                if ((Exec(w.Body, FlowType.Break | FlowType.Continue) & ~FlowType.Continue) != FlowType.None)
                    return;

                v = w.Expression.Eval();

                if (!v.IsReal)
                    ThrowError(Error.ExpectedBooleanExpression);
            }
        }

        [Statement(Kind = StatementKind.Repeat)]
        public static void Repeat(Statement s)
        {
            var repeat = (Repeat)s;

            Value v = repeat.Expression.Eval();

            if (!v.IsReal)
                ThrowError(Error.RepeatExpression);

            int times = (int)Math.Round(v.Real);

            while (times > 0)
            {
                if ((Exec(repeat.Body, FlowType.Continue | FlowType.Break) & ~FlowType.Continue) != FlowType.None)
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

        static void ThrowError(Error e)
        {
            Errors.Throw(e, Interpreter.ExecutingNode.Line, Interpreter.ExecutingNode.Column);
        }
        
        // This function is called by non-loop statements with embedded statements. The calling statement must
        // return if Exec(s) != FlowType.None.
        internal static FlowType Exec(Statement inner)
        {
            using (new SyntaxTreeScope(inner))
            {
                FlowType t = inner.Execute();
                Interpreter.ProgramFlow |= t;
                return t;
            }
        }

        /* This function is called by loop statements to execute embedded statements. You can catch
         * program flow statements, to keep them from falling through, like this:
         * switch (Exec(s, FlowType.Break|FlowType.Continue))
         * {
         * case FlowType.Break:
         *     goto End;
         * case FlowType.Continue:
         *     goto Test;
         * default:
         *     return;
         * }
         */
        internal static FlowType Exec(Statement inner, FlowType Catch)
        {
            using (new SyntaxTreeScope(inner))
            {
                FlowType t = inner.Execute();
                Interpreter.ProgramFlow |= t & ~Catch;
                return t;
            }
        }
        #endregion
    }
}
