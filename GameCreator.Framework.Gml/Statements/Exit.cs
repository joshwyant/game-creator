using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Exit : Statement
    {
        public Exit(int l, int c) : base(l, c) { }

        public override StatementKind Kind
        {
            get { return StatementKind.Exit; }
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter, bool semicolon)
        {
            writer.WriteLine("exit");
            if (semicolon)
                writer.WriteLine(";");
        }
    }
}
