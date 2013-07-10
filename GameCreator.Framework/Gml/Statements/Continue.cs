using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Continue : Statement
    {
        public Continue(int l, int c) : base(l, c) { }
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
