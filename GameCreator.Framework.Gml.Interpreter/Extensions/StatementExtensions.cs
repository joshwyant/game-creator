using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class StatementExtensions
    {
        public static FlowType Execute(this Statement s)
        {
            using (new SyntaxTreeScope(s))
            {
                Interpreter.ProgramFlow = FlowType.None;
                Delegator.StatementExecutors[s.Kind](s);
                return Interpreter.ProgramFlow;
            }
        }
    }
}
