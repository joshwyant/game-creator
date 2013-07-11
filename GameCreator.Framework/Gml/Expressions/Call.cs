using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Call : Expression
    {
        BaseFunction f;
        Expression[] exprs;
        public Call(BaseFunction func, Expression[] expressions, int line, int col)
            : base(line, col)
        {
            f = func;
            exprs = expressions;
        }
        public override Value Eval()
        {
            List<Value> vals = new List<Value>();
            foreach (Expression e in exprs)
                vals.Add(e.Eval());
            return f.Execute(vals.ToArray());
        }
        public override string ToString()
        {
            string[] t = new string[exprs.Length];
            int i = 0;
            foreach(Expression e in exprs)
                t[i++] = e.ToString();
            return f.Name + "(" + string.Join(", ", t) + ")";
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Call; }
        }
    }
}
