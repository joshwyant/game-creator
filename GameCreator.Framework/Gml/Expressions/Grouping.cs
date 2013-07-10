using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Grouping : Expr
    {
        Expr expr;
        public Grouping(Expr e, int line, int col) : base(line, col) { expr = e; }
        public override Value Eval()
        {
            return expr.Eval();
        }
    }
}