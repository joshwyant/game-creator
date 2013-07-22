using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom.Compiler;

namespace GameCreator.Framework.Gml
{
    public class Sequence : Statement
    {
        public Statement First { get; set; }
        public Statement Second { get; set; }

        public Sequence(Statement s1, Statement s2, int line, int col)
            : base(line, col)
        {
            First = s1;
            Second = s2;
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Sequence; }
        }

        public override void Optimize()
        {
            First.Optimize();
            Second.Optimize();

            if (First.Kind == StatementKind.Nop && Second.Kind == StatementKind.Sequence)
            {
                First = (Second as Sequence).First;
                Second = (Second as Sequence).Second;
            }
        }

        internal override void Write(IndentedTextWriter writer, GmlFormatter formatter, bool semicolon)
        {
            // Write the sequence with curly braces.
            Write(writer, formatter, semicolon, true);
        }

        void Write(IndentedTextWriter writer, GmlFormatter formatter, bool semicolon, bool curlyBraces)
        {
            Sequence seq;
            if (curlyBraces)
            {
                writer.WriteLine("{");
                writer.Indent++;
            }
            if (First.Kind == StatementKind.Sequence)
            {
                // Write the sequence without curly braces.
                seq = (Sequence)First;
                seq.Write(writer, formatter, semicolon, false);
            }
            else
                First.Write(writer, formatter);
            if (Second.Kind == StatementKind.Sequence)
            {
                // Write the sequence without curly braces.
                seq = (Sequence)Second;
                seq.Write(writer, formatter, semicolon, false);
            }
            else
                Second.Write(writer, formatter);
            if (curlyBraces)
            {
                writer.Indent--;
                writer.WriteLine("}");
            }
        }
    }
}
