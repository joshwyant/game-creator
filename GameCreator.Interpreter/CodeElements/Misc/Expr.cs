using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Interpreter
{
    public class Expr : Node
    {
        public virtual Value Eval()
        {
            return new Value();
        }
    }
}
