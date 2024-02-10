using System;
using System.Collections.Generic;
using System.Text;


namespace GameCreator.Framework.Gml
{
    public abstract class Expression : AstNode
    {
        public Expression(int line, int col) : base(line, col) { }

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

        protected Expression Fold(Expression expr1, Expression expr2, Func<double, double, bool> reducer)
        {
            return Fold(expr1, expr2, (v1, v2) => reducer(v1, v2) ? 1.0 : 0.0);
        }

        protected Expression Fold(Expression expr1, Expression expr2, Func<double, double, double> realReducer, Func<string, string, string> stringReducer)
        {
            var e1 = expr1.Reduce();
            var e2 = expr2.Reduce();

            if (e1.Kind == ExpressionKind.Constant && e2.Kind == ExpressionKind.Constant)
            {
                var v1 = ((Constant)e1).Value;
                var v2 = ((Constant)e2).Value;

                if (v1.IsReal && v2.IsReal)
                    return new Constant(realReducer(v1.Real, v2.Real), Line, Column);

                if (v1.IsString && v2.IsString)
                    return new Constant(stringReducer(v1.String, v2.String), Line, Column);
            }

            return this;
        }

        protected Expression Fold(Expression expr, Func<double, double> reducer)
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

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        { }
    }
}
