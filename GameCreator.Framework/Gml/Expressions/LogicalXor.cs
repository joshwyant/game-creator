using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class LogicalXor : Expr
    {
        Expr expr1, expr2;
        public LogicalXor(Expr e1, Expr e2, int l, int c) : base(l, c) { expr1 = e1; expr2 = e2; }
        public override Value Eval()
        {
            Value v1 = expr1.Eval(), v2 = expr2.Eval();
            if (!v1.IsReal || !v2.IsReal) Error("Wrong type of arguments for ^^.");
            return (v1.Real > 0) ^ (v2.Real > 0) ? new Value(1.0) : Value.Zero;
        }
    }
}
