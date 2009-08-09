using System;
namespace GameCreator.Interpreter
{
    class Complement : Expr
    {
        Expr expr;
        public Complement(Expr e) { expr = e; }
        public override Value Eval()
        {
            Value v = expr.Eval();
            if (!v.IsReal) throw new ProgramError("Wrong type of arguments to unary operator.");
            return new Value((double)~(long)Math.Round(v.Real));
        }
    }
}