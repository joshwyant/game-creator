using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework
{
    // The attribute class that marks GML functions
    [System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class GmlFunctionAttribute : Attribute
    {
        public readonly int Argc;

        // This is a positional argument
        public GmlFunctionAttribute(int argc)
        {
            Argc = argc;
        }

        public GmlFunctionAttribute()
        {
            Argc = -1;
        }

        public string Name { get; set; }
    }
}
