using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    class Return : Stmt
    {
        Expr expr;
        public Return(Expr e) { expr = e; }
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
