using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class For : Statement
    {
        public Statement stmt1, stmt2, stmt3;
        public Expression expr;
        public For(Statement init, Expression test, Statement loop, Statement stmt, int l, int c)
            : base(l, c)
        {
            stmt1 = init;
            stmt2 = loop;
            stmt3 = stmt;
            expr = test;
        }
        protected override void run()
        {
            // Game Maker allows continues and breaks AFTER the initialization statment.
            if (Exec(stmt1) != FlowType.None) return;
            loop:
            Value v = expr.Eval();
            if (!v.IsReal) Error("Expression expected");
            if (v <= 0.5) return;
            if ((Exec(stmt3, FlowType.Continue | FlowType.Break) & ~FlowType.Continue) != FlowType.None) return;
            if (Exec(stmt2) != FlowType.None) return;
            goto loop;
        }
        public override string ToString()
        {
            return string.Format("for ({0};{1};{2}) {3}", stmt1, expr, stmt2, stmt3);
        }
        public override StatementKind Kind
        {
            get { return StatementKind.For; }
        }

        public override void Optimize()
        {
            expr = expr.Reduce();
            stmt1.Optimize();
            stmt2.Optimize();
            stmt3.Optimize();
        }
    }
}
