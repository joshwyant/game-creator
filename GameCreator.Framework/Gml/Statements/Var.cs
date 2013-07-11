using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Var : Statement
    {
        string[] vars;
        public Var(string[] v, int l, int c) : base(l, c) { vars = v; }
        protected override void run()
        {
            ExecutionContext.LocalVars(vars);
        }
        public override string ToString()
        {
            return "var "+string.Join(", ", vars);
        }
        public override StatementKind Kind
        {
            get { return StatementKind.Var; }
        }
    }
}
