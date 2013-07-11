using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Sequence : Statement
    {
        public Statement stmt1;
        public Statement stmt2;
        public Sequence(Statement s1, Statement s2, int line, int col)
            : base(line, col)
        {
            stmt1 = s1;
            stmt2 = s2;
        }
        protected override void run()
        {
            if (Exec(stmt1) != FlowType.None) return;
            if (Exec(stmt2) != FlowType.None) return;
        }
        public override string ToString()
        {
            return stmt1.ToString() + "; " + stmt2.ToString();
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Sequence; }
        }
    }
}
