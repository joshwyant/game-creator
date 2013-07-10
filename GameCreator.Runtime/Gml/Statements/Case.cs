using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Case : Stmt
    {
        Expr expr;
        public Case(Expr x, int l, int c) : base(l, c) { expr = x; }
        // This will get run as a normal statement when not in a switch block, and will trigger the exception.
        // A switch block handles this statement specially.
        protected override void run()
        {
            Error("Case statement only allowed inside switch statement.");
        }
        public Value Eval()
        {
            return expr.Eval();
        }
    }
}
