using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public abstract class BinaryExpression : Expression
    {
        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public BinaryExpression(Expression e1, Expression e2, int line, int col) : base(line, col) { Left = e1; Right = e2; }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.None; }
        }

        public abstract string Operator { get; }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            Left.Write(writer, formatter);
            writer.Write(string.Concat(formatter.Padding, Operator, formatter.Padding));
            Right.Write(writer, formatter);
        }
    }
}
