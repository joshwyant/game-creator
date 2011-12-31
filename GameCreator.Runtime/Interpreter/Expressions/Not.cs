using System;
namespace GameCreator.Runtime.Interpreter
{
    class Not : Expr
    {
        Expr expr;
        public Not(Expr e, int l, int c) : base(l, c) { expr = e; }
        public override Value Eval()
        {
            Value v = expr.Eval();
            if (!v.IsReal) Error("Wrong type of arguments to unary operator.");
            return v.Real >= 0 ? Value.Zero : Value.One;
        }
    }
}