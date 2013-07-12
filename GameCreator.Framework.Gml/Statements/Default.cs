using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Default : Statement
    {
        public Default(int l, int c)
            : base(l, c) { }

        public override StatementKind Kind
        {
            get { return StatementKind.Default; }
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            throw new NotImplementedException();
        }
    }
}
