using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    class Continue : Stmt
    {
        public Continue() { }
        protected override void run()
        {
            ProgramFlow = FlowType.Continue;
        }
        public override string ToString()
        {
            return "continue";
        }
    }
}
