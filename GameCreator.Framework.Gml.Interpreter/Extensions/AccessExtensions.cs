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
            Value v1, v2;

            if (a.Indices.Length != 0)
            {
                if (a.Indices.Length == 1)
                {
                    v2 = a.Indices[0].Eval();
                    if (!v2.IsReal)
                        throw new ProgramError(Error.WrongArrayIndexType);
                    i2 = v2;
                }
                else
                {
                    v1 = a.Indices[0].Eval();
                    v2 = a.Indices[1].Eval();
                    if (!(v1.IsReal && v2.IsReal))
                        throw new ProgramError(Error.WrongArrayIndexType);
                    i1 = v1;
                    i2 = v2;
                }
            }

            if (i1 < 0 || i2 < 0)
                throw new ProgramError(Error.NegativeArrayIndex);

            if (i1 >= 32000 || i2 >= 32000)
                throw new ProgramError(Error.ArrayBounds);

            return a.Lefthand == null ? Value.Null : a.Lefthand.Eval();
        }

        public static void Set(this Access a, Value v)
        {
            int i1, i2;

            var left = a.Dereference(out i1, out i2);

            if (!left.IsReal)
                throw new ProgramError(Error.WrongVariableIndexType);

            if (a.Lefthand == null)
                ExecutionContext.SetVar(a.Name, i1, i2, v);
            else
                ExecutionContext.SetVar(left, a.Name, i1, i2, v);
        }
    }
}
