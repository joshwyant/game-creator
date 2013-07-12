using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class While : Statement
    {
        public Expression Expression { get; set; }
        public Statement Body { get; set; }
        public While(Expression e, Statement s, int line, int col) 
            : base(line,col)
        {
            Expression = e;
            Body = s;
        }

        public override string ToString()
        {
            return string.Format("while {0} {1}", Expression, Body);
        }

        public override StatementKind Kind
        {
            get { return StatementKind.While; }
        }

        public override void Optimize()
        {
            Expression = Expression.Reduce();
            Body.Optimize();
        }

    }
}
