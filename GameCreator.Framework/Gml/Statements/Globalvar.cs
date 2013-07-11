using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Globalvar : Statement
    {
        string[] vars;
        public Globalvar(string[] v, int line, int col) : base(line, col) { vars = v; }
        protected override void run()
        {
            ExecutionContext.GlobalVars(vars);
        }
        public override string ToString()
        {
            return "globalvar " + string.Join(", ", vars);
        }
        public override StatementKind Kind
        {
            get { return StatementKind.Globalvar; }
        }
    }
}
