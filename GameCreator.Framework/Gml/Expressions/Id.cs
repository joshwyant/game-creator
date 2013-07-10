using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Id : Expression
    {
        string n;
        public Id(string n, int line, int col) : base(line, col) { this.n = n; }
        public override string ToString() { return n; }
    }
}
