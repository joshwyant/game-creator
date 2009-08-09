using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    class Break : Stmt
    {
        public Break() { }
        protected override void run()
        {
            ProgramFlow = FlowType.Break;
        }
        public override string ToString()
        {
            return "break";
        }
    }
}
