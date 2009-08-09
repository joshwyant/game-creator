using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    class Id : Expr
    {
        string n;
        public Id(string n) { this.n = n; }
        public override string ToString() { return n; }
    }
}
