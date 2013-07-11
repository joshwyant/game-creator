using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class LogicalAnd : Expression
    {
        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public LogicalAnd(Expression e1, Expression e2, int l, int c) : base(l, c) { Left = e1; Right = e2; }
        public override Value Eval()
        {
            Value v1 = Left.Eval(), v2 = Right.Eval();
            if (!v1.IsReal || !v2.IsReal) Error("Wrong type of arguments for &&.");
            return v1.Real > 0 && v2.Real > 0 ? new Value(1.0) : Value.Zero;
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.LogicalAnd; }
        }
        public override Expression Reduce()
        {
            return Fold(Left, Right, (v1, v2) => v1 > 0 && v2 > 0);
        }
    }
}
