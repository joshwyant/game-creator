using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Runtime
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
}
