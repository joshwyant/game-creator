using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public class InstanceScope : IDisposable
    {
        public Instance Instance { get; set; }
        public Instance Other { get; set; }
        public ExecutionScope Scope { get; set; }

        public InstanceScope(Instance inst, bool enterFrame)
        {
            Instance = inst;
            Other = ExecutionContext.Current;

            ExecutionContext.Current = inst;
            if (enterFrame)
                Scope = new ExecutionScope();
        }

        public InstanceScope(Instance inst)
            : this(inst, true) { }

        public void Dispose()
        {
            if (Scope != null)
                Scope.Dispose();

            ExecutionContext.Current = Other;
        }
    }
}
