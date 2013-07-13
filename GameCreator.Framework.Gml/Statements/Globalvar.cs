using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Globalvar : Statement
    {
        public string[] Variables { get; set; }

        public Globalvar(string[] v, int line, int col)
            : base(line, col)
        {
            Variables = v;
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Globalvar; }
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            writer.Write("globalvar ");
            for (var i = 0; i < Variables.Length; i++)
            {
                if (i != 0)
                    writer.Write("," + formatter.Padding);

                writer.Write(Variables[i]);
            }
            writer.WriteLine(";");
        }
    }
}
