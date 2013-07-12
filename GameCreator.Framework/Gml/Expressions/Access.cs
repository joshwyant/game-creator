using System;
using System.Collections.Generic;
using System.Text;


namespace GameCreator.Framework.Gml
{
    public class Access : Expression
    {
        public Expression Lefthand { get; set; }
        public string Name { get; set; }
        public Expression[] Indices { get; set; }

        public Access(Expression left, string n, Expression[] ind, int l, int c)
            : base(l, c)
        {
            Lefthand = left; Name = n; Indices = ind;
        }

        // TODO: TRANSFER TO GameCreator.Framework.GML.Interpreter
        public void Set(Value v)
        {
            //int i1, i2;
            //int left = info(out i1, out i2);
            //if (Lefthand == null)
            //    ExecutionContext.SetVar(Name, i1, i2, v);
            //else
            //    ExecutionContext.SetVar(left, Name, i1, i2, v);
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Access; }
        }

    }
}
