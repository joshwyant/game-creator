using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Runtime;

namespace GameCreator.Framework.Gml.Interpreter
{
    public class ScriptFunction : ExecutableFunction, IGml
    {
        public string Code { get; set; }
        public CodeUnit Unit { get; set; }

        public ScriptFunction(string name, string code) : base(name, -1)
        {
            Code = code;
            Unit = CodeUnit.Get(this);
        }

        public void Compile()
        {
            Unit.Compile();
        }

        public override Value Execute(params Value[] parameters)
        {
            ExecutionContext.Returned = default(Value);

            using (new ExecutionScope(parameters))
            {
                Unit.Run();

                return ExecutionContext.Returned;
            }
        }
    }
}
