using System;
namespace GameCreator.Framework.Gml
{
    public class Plus : UnaryExpression
    {
        public Plus(Expression operand, int line, int col)
            : base(operand, line, col) { }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Plus; }
        }

        public override Expression Reduce()
        {
            return Fold(Operand, v => v);
        }
    }
}