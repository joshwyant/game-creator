using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Interpreter
{
    class Globalvar : Stmt
    {
        string[] vars;
        public Globalvar(string[] v, int line, int col) : base(line, col) { vars = v; }
        protected override void run()
        {
            Env.GlobalVars(vars);
        }
        public override string ToString()
        {
            return "globalvar " + string.Join(", ", vars);
        }
    }
}
