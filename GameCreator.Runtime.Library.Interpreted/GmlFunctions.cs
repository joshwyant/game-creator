using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GameCreator.Framework;
using GameCreator.Framework.Gml;
using GameCreator.Framework.Gml.Interpreter;

namespace GameCreator.Runtime.Library.Interpreted
{
    public static class GmlFunctions
    {
        [GmlFunction]
        public static Value execute_string(string code)
        {
            Interpreter.Returned = 0;
            CodeUnit.Get(code).Run();
            return Interpreter.Returned;
        }
    }
}
