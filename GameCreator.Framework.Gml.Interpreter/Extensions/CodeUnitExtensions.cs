using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class CodeUnitExtensions
    {
        public static void Run(this CodeUnit unit)
        {
            (unit.ParseTree as Statement).Execute();
        }

        public static Value Eval(this CodeUnit unit)
        {
            return (unit.ParseTree as Expression).Eval();
        }
    }
}
