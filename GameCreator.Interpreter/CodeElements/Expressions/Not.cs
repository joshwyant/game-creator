using System;
namespace GameCreator.Interpreter
{
    class Not : Expr
    {
        Expr expr;
        public Not(Expr e) { expr = e; }
        public override Value Eval()
        {
            Value v = expr.Eval();
            if (!v.IsReal) throw new ProgramError("Wrong type of arguments to unary operator.");
            return v.Real >= 0 ? Value.Zero : Value.One;
        }
    }
}