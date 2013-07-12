using System;
using System.Collections.Generic;
using System.Text;


namespace GameCreator.Framework.Gml
{
    public abstract class AstNode
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public AstNode(int line, int col) { Line = line; Column = col; }
    }
}
