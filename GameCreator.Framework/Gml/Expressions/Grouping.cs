using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Grouping : Expression
    {
        public Expression Operand { get; set; }

        public Grouping(Expression e, int line, int col) : base(line, col) { Operand = e; }
        public override Value Eval()
        {
            return Operand.Eval();
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Grouping; }
        }
        public override Expression Reduce()
        {
            return Operand.Reduce();
        }
    }
}