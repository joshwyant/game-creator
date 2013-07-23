using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Default : Statement
    {
        public Default(int l, int c)
            : base(l, c) { }

        public override StatementKind Kind
        {
            get { return StatementKind.Default; }
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter, bool semicolon)
        {
            var indent = writer.Indent;

            if (indent != 0) writer.Indent--;
            writer.WriteLine("default:");
            if (indent != 0) writer.Indent++;
        }
    }
}
