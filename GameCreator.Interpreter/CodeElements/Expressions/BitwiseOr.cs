using System;
namespace GameCreator.Interpreter
{
    class BitwiseOr : Expr
    {
        Expr expr1, expr2;
        public BitwiseOr(Expr e1, Expr e2, int l, int c):base(l,c) { expr1 = e1; expr2 = e2; }
        public override Value Eval()
        {
            Value v1 = expr1.Eval(), v2 = expr2.Eval();
            if (!(v1.IsReal && v2.IsReal)) Error("Wrong type of arguments for |.");
            return new Value((double)((long)Math.Round(v1.Real) | (long)Math.Round(v2.Real)));
        }
    }
}