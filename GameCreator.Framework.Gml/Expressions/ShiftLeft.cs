using System;
namespace GameCreator.Framework.Gml
{
    public class ShiftLeft : BinaryExpression
    {
        public ShiftLeft(Expression left, Expression right, int line, int col)
            : base(left, right, line, col) { }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.ShiftLeft; }
        }
        public override Expression Reduce()
        {
            return Fold(Left, Right, (v1, v2) => (double)(Convert.ToInt64(v1) << (int)Convert.ToInt64(v2)));
        }

        public override string Operator
        {
            get { return "<<"; }
        }
    }
}