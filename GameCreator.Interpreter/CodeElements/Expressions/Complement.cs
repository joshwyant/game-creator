using System;
namespace GameCreator.Interpreter
{
    class Complement : Expr
    {
        Expr expr;
        public Complement(Expr e, int line, int col) : base(line, col) { expr = e; }
        public override Value Eval()
        {
            Value v = expr.Eval();
            if (!v.IsReal) Error("Wrong type of arguments to unary operator.");
            return new Value((double)~(long)Math.Round(v.Real));
        }
    }
}