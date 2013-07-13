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
        }

        internal override void Write(IndentedTextWriter writer, GmlFormatter formatter)
        {
            // Write the sequence with curly braces.
            Write(writer, formatter, true);
        }

        void Write(IndentedTextWriter writer, GmlFormatter formatter, bool curlyBraces)
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
                seq.Write(writer, formatter, false);
            }
            else
                First.Write(writer, formatter);
            if (Second.Kind == StatementKind.Sequence)
            {
                // Write the sequence without curly braces.
                seq = (Sequence)Second;
                seq.Write(writer, formatter, false);
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
