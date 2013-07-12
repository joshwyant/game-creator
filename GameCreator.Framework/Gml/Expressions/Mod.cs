using System;
namespace GameCreator.Framework.Gml
{
    public class Mod : BinaryExpression
    {
        public Mod(Expression left, Expression right, int line, int col)
            : base(left, right, line, col) { }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Mod; }
        }
        public override Expression Reduce()
        {
            return Fold(Left, Right, (v1, v2) => (double)((long)v1 % (long)v2));
        }
    }
}