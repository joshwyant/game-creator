using System;
using System.Collections.Generic;
using System.Text;


namespace GameCreator.Framework.Gml
{
    public abstract class Statement : AstNode
    {
        public Statement(int line, int col) : base(line, col) { }

        public abstract StatementKind Kind { get; }

        public static Statement Nop { get { return new Nop(0, 0); } }

        public virtual void Optimize() { }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        { }
    }
}
