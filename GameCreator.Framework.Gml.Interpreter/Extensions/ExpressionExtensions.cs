using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class ExpressionExtensions
    {
        public static Value EvalOptimized(this Expression e)
        {
            return Delegator.ExpressionEvaluators[e.Kind](e.Reduce());
        }

        public static Value Eval(this Expression e)
        {
            return Delegator.ExpressionEvaluators[e.Kind](e);
        }
    }
}
