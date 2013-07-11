using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Nop : Statement
    {
        public Nop(int line, int col) : base(line, col)
        {

        }

        public override StatementKind Kind
        {
            get { return StatementKind.Nop; }
        }
    }
}
