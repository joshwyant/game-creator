using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Runtime;

namespace GameCreator.Framework.Gml.Interpreter
{
    // Base class for functions and scripts
    public class ExecutableFunction : BaseFunction
    {
        public ExecutableFunction(string n, int argc) 
            : base(n, argc) { }

        public virtual Value Execute(params Value[] args)
        {
            return Value.Zero;
        }
    }
}
