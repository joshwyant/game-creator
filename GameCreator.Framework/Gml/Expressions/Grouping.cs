using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Grouping : Expression
    {
        Expression expr;
        public Grouping(Expression e, int line, int col) : base(line, col) { expr = e; }
        public override Value Eval()
        {
            return expr.Eval();
        }

        public override void Emit(Intermediate.FunctionBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}