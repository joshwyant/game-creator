using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Exit : Statement
    {
        public Exit(int l, int c) : base(l, c) { }

        public override string ToString()
        {
            return "exit";
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Exit; }
        }
    }
}
