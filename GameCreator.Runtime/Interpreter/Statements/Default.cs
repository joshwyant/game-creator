using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Interpreter
{
    class Default : Stmt
    {
        public Default(int l, int c) :base(l,c) { }
        // This will get run as a normal statement when not in a switch block, and will trigger the exception.
        // A switch block handles this statement specially.
        protected override void run()
        {
            Error("Default statement only allowed inside switch statement.");
        }
    }
}
