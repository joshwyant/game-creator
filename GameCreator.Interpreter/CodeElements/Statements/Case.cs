using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    class Case : Stmt
    {
        Expr expr;
        public Case(Expr x) { expr = x; }
        // This will get run as a normal statement when not in a switch block, and will trigger the exception.
        // A switch block handles this statement specially.
        protected override void run()
        {
            throw new ProgramError("Case statement only allowed inside switch statement.");
        }
        public Value Eval()
        {
            return expr.Eval();
        }
    }
}
