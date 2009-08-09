using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    class CallStmt : Stmt
    {
        Call c;
        public CallStmt(BaseFunction func, Expr[] expressions)
        {
            c = new Call(func, expressions);
        }
        protected override void run()
        {
            c.Eval();
        }
        public override string ToString()
        {
            return c.ToString();
        }
    }
}
