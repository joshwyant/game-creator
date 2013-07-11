using System;
namespace GameCreator.Framework.Gml
{
    public class Complement : Expression
    {
        public Expression Operand { get; set; }
        
        public Complement(Expression e, int line, int col) : base(line, col) { Operand = e; }
        public override Value Eval()
        {
            Value v = Operand.Eval();
            if (!v.IsReal) Error("Wrong type of arguments to unary operator.");
            return (double)~Convert.ToInt64(v.Real);
        }

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