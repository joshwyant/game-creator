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
            ExecutionContext.Enter();
        }
        public ExecutionScope(params Value[] args)
            : this()
        {
            ExecutionContext.SetArguments(args);
        }

        public void Dispose()
        {
            ExecutionContext.Leave();
        }
    }
}
