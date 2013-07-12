using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Do : Statement
    {
        public Expression Expression { get; set; }
        public Statement Body { get; set; }

        public Do(Statement s, Expression e, int l, int c)
            : base(l, c)
        {
            Expression = e;
            Body = s;
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Do; }
        }

        public override void Optimize()
        {
            Expression = Expression.Reduce();

            Body.Optimize();
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            throw new NotImplementedException();
        }
    }
}