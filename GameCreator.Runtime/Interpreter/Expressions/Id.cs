using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Interpreter
{
    class Id : Expr
    {
        string n;
        public Id(string n, int line, int col) : base(line, col) { this.n = n; }
        public override string ToString() { return n; }
    }
}
