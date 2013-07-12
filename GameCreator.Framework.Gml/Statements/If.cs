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

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            throw new NotImplementedException();
        }
    }
}
