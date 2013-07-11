using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Return : Statement
    {
        Expression expr;
        public Return(Expression e, int line, int col) : base(line, col) { expr = e; }
        protected override void run()
        {
            ExecutionContext.Returned = expr.Eval();
            ProgramFlow = FlowType.Exit;
        }
        public override string ToString()
        {
            return "return " + expr.ToString();
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Return; }
        }
    }
}
