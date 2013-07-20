using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Runtime;
using System.Linq;
using System.IO;

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
            var script = Script.Manager.Where(s => s.Value.Name == Name).Single().Value;
            script.ExecutionDelegate = Execute;
        }

        public override Value Execute(params Value[] parameters)
        {
            Interpreter.Returned = default(Value);

            using (new ExecutionScope(parameters))
            {
                Unit.Run();

                return Interpreter.Returned;
            }
        }

        public TextReader GetCodeReader()
        {
            return new StringReader(Code);
        }
    }
}
