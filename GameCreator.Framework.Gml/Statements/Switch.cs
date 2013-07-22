using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Switch : Statement
    {
        public Expression Expression { get; set; }
        public IEnumerable<Statement> Statements { get; set; }

        public Switch(Expression x, IEnumerable<Statement> y, int line, int col)
            : base(line, col)
        {
            Expression = x;
            Statements = y;
        }
        
        public override StatementKind Kind
        {
            get { return StatementKind.Switch; }
        }

        public override void Optimize()
        {
            Expression = Expression.Reduce();

            foreach (var stmt in Statements)
                stmt.Optimize();
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter, bool semicolon)
        {
            writer.Write(string.Concat("switch", formatter.Padding, "("));
            Expression.Write(writer, formatter);
            writer.WriteLine(")");
            writer.WriteLine("{");
            writer.Indent++;
            foreach (var stmt in Statements)
                stmt.Write(writer, formatter);
            writer.Indent--;
            writer.WriteLine("}");
        }
    }
}
