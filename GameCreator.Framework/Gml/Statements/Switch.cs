using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Switch : Statement
    {
        public Expression Expression { get; set; }
        public IEnumerable<Statement> Statements { get; set; }

        public Switch(Expression x, IEnumerable<Statement> y, int line, int col)
            : base(line, col)
        {
            Expression = x;
            Statements = y;
        }
        
        public override StatementKind Kind
        {
            get { return StatementKind.Switch; }
        }

        public override void Optimize()
        {
            Expression = Expression.Reduce();

            foreach (var stmt in Statements)
                stmt.Optimize();
        }
    }
}
