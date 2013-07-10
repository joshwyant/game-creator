using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class If : Stmt
    {
        public Expr expr;
        public Stmt stmt1;
        public Stmt stmt2;
        public If(Expr e, Stmt s, int l, int c)
            : base(l, c)
        {
            expr = e;
            stmt1 = s;
            stmt2 = Stmt.Null;
        }
        public If(Expr e, Stmt t, Stmt f, int l, int c)
            : base(l, c)
        {
            expr = e;
            stmt1 = t;
            stmt2 = f;
        }
        protected override void run()
        {
            Value v = expr.Eval();
            if (!v.IsReal) Error("Expression expected");
            if (v)
            {
                if (Exec(stmt1) != FlowType.None) return;
            }
            else
            {
                if (Exec(stmt2) != FlowType.None) return;
            }
        }
        public override string ToString()
        {
            if (stmt2 == Stmt.Null)
                return string.Format("if {0} {1}", expr, stmt1);
            else
                return string.Format("if {0} {1} else {2}", expr, stmt1, stmt2);
        }
    }
}
