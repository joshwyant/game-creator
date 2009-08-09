using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    class Do : Stmt
    {
        public Expr expr;
        public Stmt stmt;
        public Do(Stmt s, Expr e)
        {
            expr = e;
            stmt = s;
        }
        protected override void run()
        {
            Value v;
            do
            {
                if ((Exec(stmt, FlowType.Continue | FlowType.Break) & ~ FlowType.Continue) == FlowType.None)
                {
                    v = expr.Eval();
                    if (!v.IsReal) throw new ProgramError("Boolean expression expected");
                }
                else break;
            } while (v.Real <= 0.0);
        }
        public override string ToString()
        {
            return "do " + stmt.ToString() + " until " + expr.ToString();
        }
    }
}