using System;
namespace GameCreator.Framework.Gml
{
    public class Div : BinaryExpression
    {
        public Div(Expression left, Expression right, int line, int col)
            : base(left, right, line, col) { }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Div; }
        }

        public override Expression Reduce()
        {
            return Fold(Left, Right, (v1, v2) => (double)((long)v1 / (long)v2));
            // One way to optimize could be returning a Shift operator
        }
    }
}