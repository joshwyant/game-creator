using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Expr : Node
    {
        public Expr(int line, int col) : base(line, col) { }
        public virtual Value Eval()
        {
            return new Value();
        }
        public Value Error(string str)
        {
            throw new ProgramError(str, ErrorSeverity.Error, Line, Column);
        }
    }
}
