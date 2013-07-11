using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class While : Statement
    {
        public Expression expr;
        public Statement stmt;
        public While(Expression e, Statement s, int line, int col) : base(line,col)
        {
            expr = e;
            stmt = s;
        }
        protected override void run()
        {
            Value v = expr.Eval();
            if (!v.IsReal) Error("Boolean expression expected");
            while (v)
            {
                if ((Exec(stmt, FlowType.Break | FlowType.Continue) & ~FlowType.Continue) != FlowType.None) return;
                v = expr.Eval();
                if (!v.IsReal) Error("Boolean expression expected");
            }
        }
        public override string ToString()
        {
            return string.Format("while {0} {1}", expr, stmt);
        }
        public override StatementKind Kind
        {
            get { return StatementKind.While; }
        }

        public override void Optimize()
        {
            expr = expr.Reduce();
            stmt.Optimize();
        }

    }
}
