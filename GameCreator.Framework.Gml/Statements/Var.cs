using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GameCreator.Framework.Gml
{
    public class Var : Statement
    {
        public string[] Variables { get; set; }

        public Var(string[] v, int l, int c) : base(l, c) { Variables = v; }

        public override StatementKind Kind
        {
            get { return StatementKind.Var; }
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter, bool semicolon)
        {
            writer.Write("var");

            if (Variables.Any())
                writer.Write(" ");

            for (var i = 0; i < Variables.Length; i++)
            {
                if (i != 0)
                    writer.Write("," + formatter.Padding);

                writer.Write(Variables[i]);
            }
            if (semicolon)
                writer.WriteLine(";");
        }
    }
}
