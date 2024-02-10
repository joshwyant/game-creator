using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Break : Statement
    {
        public Break(int line, int col) : base(line, col) { }

        public override StatementKind Kind
        {
            get { return StatementKind.Break; }
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter, bool semicolon)
        {
            writer.WriteLine("break");
            if (semicolon)
                writer.WriteLine(";");
        }
    }
}
