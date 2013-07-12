using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Grouping : Expression
    {
        public Expression InnerExpression { get; set; }

        public Grouping(Expression e, int line, int col) : base(line, col) { InnerExpression = e; }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Grouping; }
        }
        public override Expression Reduce()
        {
            return InnerExpression.Reduce();
        }
    }
}