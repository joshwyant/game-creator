using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    public class ProgramError : Exception
    {
        public ProgramError(String message) : base(message) { }
    }
}
