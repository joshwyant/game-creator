using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Case : Statement
    {
        public Expression Expression { get; set; }

        public Case(Expression x, int l, int c)
            : base(l, c)
        {
            Expression = x;
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Case; }
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter, bool semicolon)
        {
            var indent = writer.Indent;

            if (indent != 0) writer.Indent--;
            writer.Write("case ");
            Expression.Write(writer, formatter);
            writer.WriteLine(":");
            if (indent != 0) writer.Indent++;
        }
    }
}
