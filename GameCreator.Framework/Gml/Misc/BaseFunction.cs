using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
	// Delegate for calling GML functions
    public delegate Value FunctionDelegate(params Value[] args);
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
    public class BaseFunction
    {
        public string Name;
        public int Argc;
        public BaseFunction(string n, int argc)
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
