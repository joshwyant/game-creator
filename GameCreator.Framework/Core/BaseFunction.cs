
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GameCreator.Framework
{
    public class BaseFunction : IFunction
    {
        public string Name { get; set; }

        public int Argc { get; set; }

        public MethodInfo MethodInfo { get; set; }

        public BaseFunction(string name, int argc, MethodInfo mi)
        {
            Name = name;
            Argc = argc;
            MethodInfo = mi;
        }
    }
}
