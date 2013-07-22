using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Repeat : Statement
    {
        public Expression Expression { get; set; }
        public Statement Body { get; set; }

        public Repeat(Expression e, Statement s, int l, int c)
            : base(l, c)
        {
            Expression = e;
            Body = s;
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Repeat; }
        }

        public override void Optimize()
        {
            Expression = Expression.Reduce();
            Body.Optimize();
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter, bool semicolon)
        {
            writer.Write(string.Concat("repeat", formatter.Padding, "("));
            Expression.Write(writer, formatter);
            writer.WriteLine(")");
            if (Body.Kind != StatementKind.Sequence)
                writer.Indent++;
            Body.Write(writer, formatter);
            if (Body.Kind != StatementKind.Sequence)
                writer.Indent--;
        }
    }
}
