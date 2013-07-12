using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Case : Statement
    {
        public Expression Expression { get; set; }

        public Case(Expression x, int l, int c)
            : base(l, c)
        {
            Expression = x;
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Case; }
        }
    }
}
