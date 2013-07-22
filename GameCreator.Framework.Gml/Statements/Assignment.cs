using System;
namespace GameCreator.Framework.Gml
{
    public class Assignment : Statement
    {
        public Access Lefthand { get; set; }
        public Expression Expression { get; set; }

        public Assignment(Access acc, Expression e, int l, int c)
            : base(l, c)
        {
            Lefthand = acc;
            Expression = e;
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Assignment; }
        }

        public override void Optimize()
        {
            Expression = Expression.Reduce();
        }

        public virtual string Operator { get { return "="; } }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter, bool semicolon)
        {
            Lefthand.Write(writer, formatter);
            writer.Write(string.Format("{1}{0}{1}", Operator, formatter.Padding));
            Expression.Write(writer, formatter);
            if (semicolon)
                writer.WriteLine(";");
        }
    }
}
