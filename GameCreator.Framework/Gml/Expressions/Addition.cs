using System;

namespace GameCreator.Framework.Gml
{
    class Addition : Expression
    {
        Expression expr1, expr2;
        public Addition(Expression e1, Expression e2, int l, int c) : base(l, c) { expr1 = e1; expr2 = e2; }
        public override Value Eval()
        {
            Value v1 = expr1.Eval(), v2 = expr2.Eval();
            if (v1.IsReal && v2.IsReal)
                return new Value(v1.Real + v2.Real);
            else if (v1.IsString && v2.IsString)
                return new Value(v1.String + v2.String);
            else
                return Error("Wrong type of arguments to +.");
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Addition; }
        }

        public override Expression Reduce()
        {
            var e1 = expr1.Reduce();
            var e2 = expr2.Reduce();

            if (e1.Kind == ExpressionKind.Constant && e2.Kind == ExpressionKind.Constant)
            {
                var v1 = ((Constant)e1).Value;
                var v2 = ((Constant)e2).Value;

                if (v1.IsReal && v2.IsReal)
                    return new Constant(v1.Real + v2.Real, Line, Column);

                if (v1.IsString && v2.IsString)
                    return new Constant(v1.String + v2.String, Line, Column);
            }

            return this;
        }
    }
}