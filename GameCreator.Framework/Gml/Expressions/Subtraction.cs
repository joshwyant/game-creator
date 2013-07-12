using System;
namespace GameCreator.Framework.Gml
{
    public class Subtraction : BinaryExpression
    {
        public Subtraction(Expression left, Expression right, int line, int col)
            : base(left, right, line, col) { }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Subtraction; }
        }
        public override Expression Reduce()
        {
            return Fold(Left, Right, (v1, v2) => v1 - v2);
        }
    }
}