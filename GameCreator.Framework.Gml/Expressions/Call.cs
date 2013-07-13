using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Call : Expression
    {
        public BaseFunction Function { get; set; }
        public Expression[] Expressions { get; set; }


        public Call(BaseFunction func, Expression[] expressions, int line, int col)
            : base(line, col)
        {
            Function = func;
            Expressions = expressions;
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Call; }
        }

        public override Expression Reduce()
        {
            var e = new Expression[Expressions.Length];

            for (int i = 0; i < e.Length; i++)
                e[i] = Expressions[i].Reduce();

            return new Call(Function, Expressions, Line, Column);
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            writer.Write(Function.Name + "(");
            for (int i = 0; i < Expressions.Length; i++)
            {
                if (i != 0)
                    writer.Write("," + formatter.Padding);
                Expressions[i].Write(writer, formatter);
            }
            writer.Write(")");
        }
    }
}
