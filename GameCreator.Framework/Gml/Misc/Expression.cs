using System;
using System.Collections.Generic;
using System.Text;


namespace GameCreator.Framework.Gml
{
    public abstract class Expression : AstNode
    {
        public Expression(int line, int col) : base(line, col) { }
        public virtual Value Eval()
        {
            return new Value();
        }
        public Value Error(string str) // Wow, this is wrong.
        {
            throw new ProgramError(str, ErrorSeverity.Error, Line, Column);
        }

        public virtual Expression Reduce()
        {
            return this;
        }

        public abstract ExpressionKind Kind { get; }

        protected Expression Fold(Expression expr1, Expression expr2, Func<double, double, double> reducer)
        {
            var e1 = expr1.Reduce();
            var e2 = expr2.Reduce();

            if (e1.Kind == ExpressionKind.Constant && e2.Kind == ExpressionKind.Constant)
            {
                var v1 = ((Constant)e1).Value;
                var v2 = ((Constant)e2).Value;

                if (v1.IsReal && v2.IsReal)
                    return new Constant(reducer(v1.Real, v2.Real), Line, Column);
            }

            return this;
        }

        protected Expression UnaryFold(Expression expr, Func<double, double> reducer)
        {
            var e = expr.Reduce();

            if (e.Kind == ExpressionKind.Constant)
            {
                var v = ((Constant)e).Value;

                if (v.IsReal)
                    return new Constant(reducer(v.Real), Line, Column);
            }

            return this;
        }
    }
}
