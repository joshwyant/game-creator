using System;
namespace GameCreator.Framework.Gml
{
    public class Not : UnaryExpression
    {
        public Not(Expression operand, int line, int col)
            : base(operand, line, col) { }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Not; }
        }

        public override Expression Reduce()
        {
            return Fold(Operand, v => v <= 0 ? 1 : 0);
        }
    }
}