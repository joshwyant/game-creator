using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class VirtualMachine
    {
        internal static FlowType ProgramFlow { get; set; }

        public static Value EvalOptimized(this Expression e)
        {
            return Delegator.ExpressionEvaluators[e.Kind](e.Reduce());
        }

        public static Value Eval(this Expression e)
        {
            return Delegator.ExpressionEvaluators[e.Kind](e);
        }

        public static FlowType Execute(this Statement s)
        {
            ProgramFlow = FlowType.None;
            Statement prev = ExecutionContext.ExecutingStatement;
            ExecutionContext.ExecutingStatement = s;
            Delegator.StatementExecutors[s.Kind](s);
            ExecutionContext.ExecutingStatement = prev;
            return ProgramFlow;
        }

        // This function is called by non-loop statements with embedded statements. The calling statement must
        // return if Exec(s) != FlowType.None.
        internal static FlowType Exec(Statement inner)
        {
            FlowType t = inner.Execute();
            ProgramFlow |= t;
            return t;
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
            FlowType t = inner.Execute();
            ProgramFlow |= t & ~Catch;
            return t;
        }
    }
}
