using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class IGmlExtensions
    {
        public static Value EvalCode(this IGml codeObject)
        {
            return CodeUnit.GetExpression(codeObject).Eval();
        }

        public static void ExecuteCode(this IGml codeObject)
        {
            CodeUnit.Get(codeObject).Run();
        }
    }
}
