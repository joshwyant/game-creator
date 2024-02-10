using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public abstract class UnaryExpression : Expression
    {
        public Expression Operand { get; set; }

        public UnaryExpression(Expression e, int line, int col) : base(line, col) { Operand = e; }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.None; }
        }
    }
}
