using System;
namespace GameCreator.Framework.Gml
{
    class Div : Expression
    {
        Expression expr1, expr2;
        public Div(Expression e1, Expression e2, int l, int c) : base(l, c) { expr1 = e1; expr2 = e2; }
        public override Value Eval()
        {
            Value v1 = expr1.Eval(), v2 = expr2.Eval();
            if (!(v1.IsReal && v2.IsReal)) Error("Wrong type of arguments to div.");
            return (double)((long)v1.Real / (long)v2.Real);
        }
    }
}