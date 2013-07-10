using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework.Intermediate;

namespace GameCreator.Framework.Gml
{
    public abstract class AstNode
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public AstNode(int line, int col) { Line = line; Column = col; }
        public abstract void Emit(FunctionBuilder builder);
    }
}
