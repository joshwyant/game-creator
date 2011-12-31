using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Interpreter
{
    class Break : Stmt
    {
        public Break(int line, int col) : base(line, col) { }
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
