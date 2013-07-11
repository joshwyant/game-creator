using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Do : Statement
    {
        public Expression expr;
        public Statement stmt;
        public Do(Statement s, Expression e, int l, int c)
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
        public override StatementKind Kind
        {
            get { return StatementKind.Do; }
        }


        public override void Optimize()
        {
            expr = expr.Reduce();

            stmt.Optimize();
        }
    }
}