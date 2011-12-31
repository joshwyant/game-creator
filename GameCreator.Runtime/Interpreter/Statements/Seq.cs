using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Interpreter
{
    class Seq : Stmt
    {
        public Stmt stmt1;
        public Stmt stmt2;
        public Seq(Stmt s1, Stmt s2, int line, int col)
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
    }
}
