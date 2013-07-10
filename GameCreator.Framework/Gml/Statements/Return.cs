using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Return : Stmt
    {
        Expr expr;
        public Return(Expr e, int line, int col) : base(line, col) { expr = e; }
        protected override void run()
        {
            Env.Returned = expr.Eval();
            ProgramFlow = FlowType.Exit;
        }
        public override string ToString()
        {
            return "return " + expr.ToString();
        }
    }
}
