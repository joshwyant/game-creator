using System;
namespace GameCreator.Framework.Gml
{
    public class Divide : BinaryExpression
    {
        public Divide(Expression left, Expression right, int line, int col)
            : base(left, right, line, col) { }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Divide; }
        }
        public override Expression Reduce()
        {
            return Fold(Left, Right, (v1, v2) => v1 / v2);
            // One way to optimize could be returning a Shift operator
        }

        public override string Operator
        {
            get { return "/"; }
        }
    }
}