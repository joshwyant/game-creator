using System;
namespace GameCreator.Framework.Gml
{
    class Plus : Expr
    {
        Expr expr;
        public Plus(Expr e, int line, int col) : base(line, col) { expr = e; }
        public override Value Eval()
        {
            Value v = expr.Eval();
            if (!v.IsReal) Error("Wrong type of arguments to unary operator.");
            return new Value(v.Real);
        }
    }
}