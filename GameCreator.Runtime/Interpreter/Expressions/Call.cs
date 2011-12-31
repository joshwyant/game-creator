using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Interpreter
{
    class Call : Expr
    {
        BaseFunction f;
        Expr[] exprs;
        public Call(BaseFunction func, Expr[] expressions, int line, int col)
            : base(line, col)
        {
            f = func;
            exprs = expressions;
        }
        public override Value Eval()
        {
            List<Value> vals = new List<Value>();
            foreach (Expr e in exprs)
                vals.Add(e.Eval());
            return f.Execute(vals.ToArray());
        }
        public override string ToString()
        {
            string[] t = new string[exprs.Length];
            int i = 0;
            foreach(Expr e in exprs)
                t[i++] = e.ToString();
            return f.Name + "(" + string.Join(", ", t) + ")";
        }
    }
}
