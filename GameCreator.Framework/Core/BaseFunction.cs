
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework
{
    public class BaseFunction : IFunction
    {
        public string Name { get; set; }

        public int Argc { get; set; }

        public BaseFunction(string name, int argc)
        {
            Name = name;
            Argc = argc;
        }
    }
}
