using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class CallStmt : Stmt
    {
        Call c;
        public CallStmt(BaseFunction func, Expr[] expressions, int l, int c)
            : base(l, c)
        {
            this.c = new Call(func, expressions, l, c);
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
