using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class If : Statement
    {
        public Expression Expression { get; set; }
        public Statement Body { get; set; }
        public Statement Else { get; set; }

        public If(Expression e, Statement s, int l, int c)
            : base(l, c)
        {
            Expression = e;
            Body = s;
            Else = Statement.Nop;
        }

        public If(Expression e, Statement t, Statement f, int l, int c)
            : base(l, c)
        {
            Expression = e;
            Body = t;
            Else = f;
        }

        public override string ToString()
        {
            if (Else is Nop)
                return string.Format("if {0} {1}", Expression, Body);
            else
                return string.Format("if {0} {1} else {2}", Expression, Body, Else);
        }

        public override StatementKind Kind
        {
            get { return StatementKind.If; }
        }

        public override void Optimize()
        {
            Expression = Expression.Reduce();
            Body.Optimize();
            Else.Optimize();
        }
    }
}
