using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework
{
    public class BaseFunction
    {
        public string Name { get; set; }
        public int Argc { get; set; }

        public BaseFunction(string n, int argc)
        {
            Name = n;
            Argc = argc;
        }
    }
}
