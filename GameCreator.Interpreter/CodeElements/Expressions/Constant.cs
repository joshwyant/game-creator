using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    class Constant : Expr
    {
        Value v;
        public Constant(string s) { v = new Value(s); }
        public Constant(double d) { v = new Value(d); }
        public override Value Eval()
        {
            return v;
        }
        public override string ToString()
        {
            return v.ToString();
        }
    }
}
