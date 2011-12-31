using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Interpreter
{
    public class ScriptFunction : BaseFunction
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
            Env.Returned = new Value();
            Env.Enter();
            Env.SetArguments(parameters);
            cu.Run();
            Env.Leave();
            return Env.Returned;
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
