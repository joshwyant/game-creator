using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class If : Statement
    {
        public Expression Expression { get; set; }
        public Statement Body { get; set; }
        public Statement Else { get; set; }

        public If(Expression e, Statement s, int l, int c)
            : base(l, c)
        {
            Expression = e;
            Body = s;
            Else = Statement.Nop;
        }

        public If(Expression e, Statement t, Statement f, int l, int c)
            : base(l, c)
        {
            Expression = e;
            Body = t;
            Else = f;
        }

        public override StatementKind Kind
        {
            get { return StatementKind.If; }
        }

        public override void Optimize()
        {
            Expression = Expression.Reduce();
            Body.Optimize();
            Else.Optimize();
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            writer.Write(string.Concat("if", formatter.Padding, "("));
            Expression.Write(writer, formatter);
            writer.WriteLine(")");
            if (Body.Kind != StatementKind.Sequence)
                writer.Indent++;
            Body.Write(writer, formatter);
            if (Body.Kind != StatementKind.Sequence)
                writer.Indent--;
            if (Else != null && Else.Kind != StatementKind.Nop)
            {
                if (Else.Kind != StatementKind.Sequence)
                    writer.Indent++;
                Else.Write(writer, formatter);
                if (Else.Kind != StatementKind.Sequence)
                    writer.Indent--;
            }
        }
    }
}
