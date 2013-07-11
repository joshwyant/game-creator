using System;
namespace GameCreator.Framework.Gml
{
    class Complement : Expression
    {
        Expression expr;
        public Complement(Expression e, int line, int col) : base(line, col) { expr = e; }
        public override Value Eval()
        {
            Value v = expr.Eval();
            if (!v.IsReal) Error("Wrong type of arguments to unary operator.");
            return (double)~Convert.ToInt64(v.Real);
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Complement; }
        }

        public override Expression Reduce()
        {
            return UnaryFold(expr, v => (double)~Convert.ToInt64(v));
        }
    }
}