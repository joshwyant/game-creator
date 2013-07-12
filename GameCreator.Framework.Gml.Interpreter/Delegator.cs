using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class Delegator
    {
        public static Dictionary<ExpressionKind, Func<Expression, Value>> ExpressionEvaluators { get; set; }

        static Delegator()
        {
            // Initialize delegator tables
            ExpressionEvaluators = new Dictionary<ExpressionKind, Func<Expression, Value>>();

            // Load the expressions delegates from the Expressions class
            var expressionsT = typeof(Expressions);

            // From each method in the class, create a delegate, and get the "kind" from the attribute.
            var evaluators = from m in expressionsT.GetMethods()
                             where m.GetCustomAttributes(typeof(ExpressionAttribute), false).Any()
                             select new
                             {
                                 (m.GetCustomAttributes(typeof(ExpressionAttribute), false).Single() as ExpressionAttribute).Kind,
                                 Delegate = Delegate.CreateDelegate(typeof(Func<Expression, Value>), m) as Func<Expression, Value>
                             };

            // Add all the expression delegates to the dictionary
            foreach (var evaluator in evaluators)
                ExpressionEvaluators.Add(evaluator.Kind, evaluator.Delegate);
        }

        public static Value EvalOptimized(this Expression e)
        {
            return ExpressionEvaluators[e.Kind](e.Reduce());
        }

        public static Value Eval(this Expression e)
        {
            return ExpressionEvaluators[e.Kind](e);
        }
    }
}
