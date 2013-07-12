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

        public override string ToString()
        {
            string[] t = new string[Expressions.Length];
            int i = 0;
            foreach (Expression e in Expressions)
                t[i++] = e.ToString();
            return Function.Name + "(" + string.Join(", ", t) + ")";
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
    }
}
