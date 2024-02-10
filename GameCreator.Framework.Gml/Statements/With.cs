using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class With : Statement
    {
        public Expression Instance { get; set; }
        public Statement Body { get; set; }

        public With(Expression e, Statement s, int l, int c)
            : base(l, c)
        {
            Instance = e; Body = s;
        }

        public override StatementKind Kind
        {
            get { return StatementKind.With; }
        }

        public override void Optimize()
        {
            Instance = Instance.Reduce();
            Body.Optimize();
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter, bool semicolon)
        {
            writer.Write(string.Concat("with", formatter.Padding, "("));
            Instance.Write(writer, formatter);
            writer.WriteLine(")");
            if (Body.Kind != StatementKind.Sequence)
                writer.Indent++;
            Body.Write(writer, formatter);
            if (Body.Kind != StatementKind.Sequence)
                writer.Indent--;
        }
    }
}
