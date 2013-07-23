using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Runtime;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class AccessExtensions
    {
        public static Value Dereference(this Access a, out int i1, out int i2)
        {
            i1 = 0; i2 = 0;

            if (a.Indices.Length != 0)
            {
                if (a.Indices.Length == 1)
                    i2 = a.Indices[0].Eval();
                else
                {
                    i1 = a.Indices[0].Eval();
                    i2 = a.Indices[1].Eval();
                }
            }

            return a.Lefthand == null ? Value.Null : a.Lefthand.Eval();
        }

        public static void Set(this Access a, Value v)
        {
            int i1, i2;

            var left = a.Dereference(out i1, out i2);

            if (a.Lefthand == null)
                ExecutionContext.SetVar(a.Name, i1, i2, v);
            else
                ExecutionContext.SetVar(left, a.Name, i1, i2, v);
        }
    }
}
