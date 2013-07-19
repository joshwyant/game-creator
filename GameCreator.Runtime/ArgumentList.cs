using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.Runtime
{
    public class ArgumentList : GetSetValue
    {
        public Value[] Values;

        public ArgumentList()
        {
            Values = new Value[16];

            for (int i = 0; i < Values.Length; i++)
                Values[i] = 0;
        }

        public Value Get(int i1, int i2)
        {
            return i2 >= 16 ? Value.Zero : Values[i2];
        }

        public void Set(int i1, int i2, Value value)
        {
            Values[i2 >= 16 ? 0 : i2] = value;
        }

        public bool CheckIndex(int i1, int i2)
        {
            return true;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }
    }
}
