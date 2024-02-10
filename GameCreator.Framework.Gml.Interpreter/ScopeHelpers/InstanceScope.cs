using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Runtime;

namespace GameCreator.Framework.Gml.Interpreter
{
    public class InstanceScope : IDisposable
    {
        public RuntimeInstance Instance { get; set; }
        public RuntimeInstance Other { get; set; }
        public ExecutionScope Scope { get; set; }

        public InstanceScope(RuntimeInstance inst, bool enterFrame)
        {
            Instance = inst;
            Other = ExecutionContext.Current;

            ExecutionContext.Current = inst;
            if (enterFrame)
                Scope = new ExecutionScope();
        }

        public InstanceScope(RuntimeInstance inst)
            : this(inst, true) { }

        public void Dispose()
        {
            if (Scope != null)
                Scope.Dispose();

            ExecutionContext.Current = Other;
        }
    }
}
