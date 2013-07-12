using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Runtime;

namespace GameCreator.Framework.Gml.Interpreter
{
    // The attribute class that marks GML functions
	[System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class GMLFunctionAttribute : Attribute
    {
        public readonly int Argc;

        // This is a positional argument
        public GMLFunctionAttribute(int argc)
        {
            Argc = argc;
        }

        public string Name { get; set; }
    }
    // Base class for functions and scripts
    public class ExecutableFunction : BaseFunction
    {
        public string Name;
        public int Argc;
        public ExecutableFunction(string n, int argc) 
            : base(n, argc) { }

        public virtual Value Execute(params Value[] args)
        {
            return Value.Zero;
        }
    }
}
