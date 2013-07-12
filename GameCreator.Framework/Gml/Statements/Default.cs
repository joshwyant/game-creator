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
    }
}
