using System;
namespace GameCreator.Framework.Gml
{
    public class Not : Expression
    {
        public Expression Operand { get; set; }

        public Not(Expression e, int l, int c) : base(l, c) { Operand = e; }
        public override Value Eval()
        {
            Value v = Operand.Eval();
            if (!v.IsReal) Error("Wrong type of arguments to unary operator.");
            return v.Real > 0 ? Value.Zero : Value.One;
        }

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