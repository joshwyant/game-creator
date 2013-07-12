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

        public override StatementKind Kind
        {
            get { return StatementKind.While; }
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
