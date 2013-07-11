using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class CallStatement : Statement
    {
        Call c;
        public CallStatement(BaseFunction func, Expression[] expressions, int l, int c)
            : base(l, c)
        {
            this.c = new Call(func, expressions, l, c);
        }
        protected override void run()
        {
            c.Eval();
        }
        public override string ToString()
        {
            return c.ToString();
        }

        public override StatementKind Kind
        {
            get { return StatementKind.CallStatement; }
        }
    }
}
