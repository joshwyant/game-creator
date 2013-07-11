using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class GreaterThan : Expression
    {
        Expression expr1, expr2;
        public GreaterThan(Expression e1, Expression e2, int line, int col) : base(line, col) { expr1 = e1; expr2 = e2; }
        public override Value Eval()
        {
            Value v1 = expr1.Eval(), v2 = expr2.Eval();
            if (v1.IsReal && v2.IsReal)
            {
                return v1.Real > v2.Real ? Value.One : Value.Zero;
            }
            else if (v1.IsString && v2.IsString)
            {
                return String.CompareOrdinal(v1.String, v2.String) > 0 ? Value.One : Value.Zero;
            }
            else return Error("Cannot compare arguments.");
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.GreaterThan; }
        }
    }
}
