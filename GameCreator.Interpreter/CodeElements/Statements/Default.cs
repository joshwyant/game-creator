using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    class Default : Stmt
    {
        public Default() { }
        // This will get run as a normal statement when not in a switch block, and will trigger the exception.
        // A switch block handles this statement specially.
        protected override void run()
        {
            throw new ProgramError("Default statement only allowed inside switch statement.");
        }
    }
}
