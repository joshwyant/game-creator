using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Runtime;

namespace GameCreator.Framework.Gml.Interpreter
{
    // Base class for functions and scripts
    public abstract class ExecutableFunction : IFunction
    {
        public int Argc { get; set; }

        public string Name { get; set; }

        public ExecutableFunction(string n, int argc)
        {
            Name = n;
            Argc = argc;
        }

        public virtual Value Execute(params Value[] args)
        {
            return Value.Zero;
        }
    }
}
