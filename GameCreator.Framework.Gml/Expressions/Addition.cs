using System;

namespace GameCreator.Framework.Gml
{
    public class Addition : BinaryExpression
    {
        public Addition(Expression left, Expression right, int line, int col)
            : base(left, right, line, col) { }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Addition; }
        }

        public override Expression Reduce()
        {
            return Fold(Left, Right, (v1, v2) => v1 + v2, (s1, s2) => s1 + s2);
        }

        public override string Operator
        {
            get { return "+"; }
        }
    }
}