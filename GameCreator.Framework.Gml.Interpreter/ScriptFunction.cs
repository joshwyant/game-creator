using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Runtime;

namespace GameCreator.Framework.Gml.Interpreter
{
    public class ScriptFunction : ExecutableFunction
    {
        CodeUnit cu;
        public ScriptFunction(string name, string code) : base(name, -1)
        {
            cu = new CodeUnit(code);
        }
        public void Compile()
        {
            cu.Compile();
        }
        public override Value Execute(params Value[] parameters)
        {
            ExecutionContext.Returned = default(Value);
            ExecutionContext.Enter();
            ExecutionContext.SetArguments(parameters);
            cu.Run();
            ExecutionContext.Leave();
            return ExecutionContext.Returned;
        }
        public string Code
        {
            get
            {
                return cu.Code;
            }
        }
    }
}
