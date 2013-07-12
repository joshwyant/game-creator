using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Equality : BinaryExpression
    {
        public Equality(Expression e1, Expression e2, int line, int col) : base(e1, e2, line, col) { }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Equality; }
        }
        public override Expression Reduce()
        {
            var e1 = Left.Reduce();
            var e2 = Right.Reduce();

            if (e1.Kind == ExpressionKind.Constant && e2.Kind == ExpressionKind.Constant)
            {
                var v1 = ((Constant)e1).Value;
                var v2 = ((Constant)e2).Value;

                if (v1.IsReal && v2.IsReal)
                    return new Constant(v1.Real == v2.Real ? 1 : 0, Line, Column);

                if (v1.IsString && v2.IsString)
                    return new Constant(String.CompareOrdinal(v1.String, v2.String) == 0 ? 1 : 0, Line, Column);
            }

            return this;
        }

        public override string Operator
        {
            get { return "=="; }
        }
    }
}