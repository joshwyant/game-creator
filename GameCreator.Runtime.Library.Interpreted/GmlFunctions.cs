using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;
using GameCreator.Framework.Gml.Interpreter;
using System.IO;
using GameCreator.Framework.Gml;

namespace GameCreator.Runtime.Library.Interpreted
{
    public static class GmlFunctions
    {
        [GmlFunction]
        public static Value execute_string(string code)
        {
            ExecutionContext.Returned = 0;
            CodeUnit.Get(code).Run();
            return ExecutionContext.Returned;
        }
    }
}
