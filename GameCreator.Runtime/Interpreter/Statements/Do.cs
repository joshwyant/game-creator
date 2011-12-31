using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Interpreter
{
    class Do : Stmt
    {
        public Expr expr;
        public Stmt stmt;
        public Do(Stmt s, Expr e, int l, int c)
            : base(l, c)
        {
            expr = e;
            stmt = s;
        }
        protected override void run()
        {
            Value v;
            do
            {
                if ((Exec(stmt, FlowType.Continue | FlowType.Break) & ~FlowType.Continue) == FlowType.None)
                {
                    v = expr.Eval();
                    if (!v.IsReal) Error("Boolean expression expected");
                }
                else break;
            } while (v);
        }
        public override string ToString()
        {
            return "do " + stmt.ToString() + " until " + expr.ToString();
        }
    }
}