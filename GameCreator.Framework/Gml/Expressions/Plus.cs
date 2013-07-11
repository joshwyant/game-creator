using System;
namespace GameCreator.Framework.Gml
{
    public class Plus : Expression
    {
        public Expression Operand { get; set; }

        public Plus(Expression e, int line, int col) : base(line, col) { Operand = e; }
        public override Value Eval()
        {
            Value v = Operand.Eval();
            if (!v.IsReal) Error("Wrong type of arguments to unary operator.");
            return new Value(v.Real);
        }

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