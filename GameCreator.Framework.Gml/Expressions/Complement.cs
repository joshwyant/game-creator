using System;
namespace GameCreator.Framework.Gml
{
    public class Complement : UnaryExpression
    {
        public Complement(Expression operand, int line, int col)
            : base(operand, line, col) { }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Complement; }
        }

        public override Expression Reduce()
        {
            return Fold(Operand, v => (double)~Convert.ToInt64(v));
        }
    }
}