using System;
using System.Collections.Generic;
using System.Text;

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

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            throw new NotImplementedException();
        }
    }
}
