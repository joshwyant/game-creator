using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Interpreter
{
    [Flags]
    public enum FlowType
    {
        None = 0,
        Continue = 1,
        Break = 2,
        Exit = 4,
    }
}
