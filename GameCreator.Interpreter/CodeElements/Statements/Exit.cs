using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    class Exit : Stmt
    {
        public Exit() { }
        protected override void run()
        {
            ProgramFlow = FlowType.Exit;
        }
        public override string ToString()
        {
            return "exit";
        }
    }
}
