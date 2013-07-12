using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class Delegator
    {
        public static Dictionary<ExpressionKind, Func<Expression, Value>> ExpressionEvaluators { get; set; }
        public static Dictionary<StatementKind, Action<Statement>> StatementExecutors { get; set; }

        static Delegator()
        {
            // Initialize delegator tables
            ExpressionEvaluators = new Dictionary<ExpressionKind, Func<Expression, Value>>();
            StatementExecutors = new Dictionary<StatementKind, Action<Statement>>();

            // Load the expressions delegates from the Expressions class
            LoadDelegates(typeof(Expressions));

            // Load the statements delegates from the Statements class
            LoadDelegates(typeof(Statements));
        }

        public static void LoadDelegates(Type t)
        {
            // From each method in the class, create a delegate, and get the "kind" from the attribute.
            var evaluators = from m in t.GetMethods()
                             where m.GetCustomAttributes(typeof(ExpressionAttribute), false).Any()
                             select new
                             {
                                 (m.GetCustomAttributes(typeof(ExpressionAttribute), false).Single() as ExpressionAttribute).Kind,
                                 Delegate = Delegate.CreateDelegate(typeof(Func<Expression, Value>), m) as Func<Expression, Value>
                             };

            // From each method in the class, create a delegate, and get the "kind" from the attribute.
            var executors = from m in t.GetMethods()
                            where m.GetCustomAttributes(typeof(StatementAttribute), false).Any()
                            select new
                            {
                                (m.GetCustomAttributes(typeof(StatementAttribute), false).Single() as StatementAttribute).Kind,
                                Delegate = Delegate.CreateDelegate(typeof(Action<Statement>), m) as Action<Statement>
                            };

            // Add all the expression delegates to the dictionary
            foreach (var evaluator in evaluators)
                ExpressionEvaluators.Add(evaluator.Kind, evaluator.Delegate);

            // Add all the statement delegates to the dictionary
            foreach (var executor in executors)
                StatementExecutors.Add(executor.Kind, executor.Delegate);
        }
    }
}
