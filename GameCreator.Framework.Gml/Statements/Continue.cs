using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Continue : Statement
    {
        public Continue(int l, int c) : base(l, c) { }

        public override StatementKind Kind
        {
            get { return StatementKind.Continue; }
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter, bool semicolon)
        {
            writer.WriteLine("continue");
            if (semicolon)
                writer.WriteLine(";");
        }
    }
}
