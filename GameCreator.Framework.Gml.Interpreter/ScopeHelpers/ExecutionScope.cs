using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public class ExecutionScope : IDisposable
    {
        public ExecutionScope()
        {
            Interpreter.Enter();
        }
        public ExecutionScope(params Value[] args)
            : this()
        {
            Interpreter.SetArguments(args);
        }

        public void Dispose()
        {
            Interpreter.Leave();
        }
    }
}
