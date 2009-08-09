using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    class While : Stmt
    {
        public Expr expr;
        public Stmt stmt;
        public While(Expr e, Stmt s)
        {
            expr = e;
            stmt = s;
        }
        protected override void run()
        {
            Value v = expr.Eval();
            if (!v.IsReal) throw new ProgramError("Boolean expression expected");
            while (v.Real > 0)
            {
                if ((Exec(stmt, FlowType.Break | FlowType.Continue) & ~FlowType.Continue) != FlowType.None) return;
                v = expr.Eval();
                if (!v.IsReal) throw new ProgramError("Boolean expression expected");
            }
        }
        public override string ToString()
        {
            return string.Format("while {0} {1}", expr, stmt);
        }
    }
}
