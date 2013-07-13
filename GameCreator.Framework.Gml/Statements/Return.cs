using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Return : Statement
    {
        public Expression Expression { get; set; }

        public Return(Expression e, int line, int col)
            : base(line, col)
        {
            Expression = e;
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Return; }
        }

        public override void Optimize()
        {
            Expression = Expression.Reduce();
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            writer.Write("return ");
            Expression.Write(writer, formatter);
            writer.WriteLine(";");
        }
    }
}
