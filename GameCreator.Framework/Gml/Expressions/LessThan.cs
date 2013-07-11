using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class LessThan : BinaryExpression
    {
        public LessThan(Expression e1, Expression e2, int line, int col) : base(e1, e2, line, col) { }

        public override Value Eval()
        {
            Value v1 = Left.Eval(), v2 = Right.Eval();
            if (v1.IsReal && v2.IsReal)
            {
                return v1.Real < v2.Real ? Value.One : Value.Zero;
            }
            else if (v1.IsString && v2.IsString)
            {
                return String.CompareOrdinal(v1.String, v2.String) < 0 ? Value.One : Value.Zero;
            }
            else return Error("Cannot compare arguments.");
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.LessThan; }
        }
        public override Expression Reduce()
        {
            return Fold(Left, Right, (v1, v2) => v1 < v2);
        }
    }
}
