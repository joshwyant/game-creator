using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class LogicalOr : BinaryExpression
    {
        public LogicalOr(Expression e1, Expression e2, int line, int col) : base(e1, e2, line, col) { }

        public override Value Eval()
        {
            Value v1 = Left.Eval(), v2 = Right.Eval();
            if (!v1.IsReal || !v2.IsReal) Error("Wrong type of arguments for ||.");
            return v1.Real > 0 || v2.Real > 0 ? new Value(1.0) : Value.Zero;
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.LogicalOr; }
        }
        public override Expression Reduce()
        {
            return Fold(Left, Right, (v1, v2) => v1 > 0 || v2 > 0);
        }
    }
}
