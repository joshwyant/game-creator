using System;
namespace GameCreator.Interpreter
{
    class Minus : Expr
    {
        Expr expr;
        public Minus(Expr e) { expr = e; }
        public override Value Eval()
        {
            Value v = expr.Eval();
            if (!v.IsReal) throw new ProgramError("Wrong type of arguments to unary operator.");
            return new Value(-v.Real);
        }
    }
}