using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Repeat : Statement
    {
        public Expression Expression { get; set; }
        public Statement Body { get; set; }

        public Repeat(Expression e, Statement s, int l, int c)
            : base(l, c)
        {
            Expression = e;
            Body = s;
        }

        public override string ToString()
        {
            return string.Format("repeat {0} {1}", Expression, Body);
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Repeat; }
        }

        public override void Optimize()
        {
            Expression = Expression.Reduce();
            Body.Optimize();
        }
    }
}
