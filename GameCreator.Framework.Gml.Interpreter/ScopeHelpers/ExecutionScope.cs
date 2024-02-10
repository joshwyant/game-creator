using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Runtime;

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
            ExecutionContext.SetArguments(args);
        }

        public void Dispose()
        {
            Interpreter.Leave();
        }
    }
}
