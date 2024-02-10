using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.Runtime
{
    public class Variable : GetSetValue
    {
        #region Values Field
        List<List<Value>> Values;
        #endregion

        #region Constructors
        public Variable()
        {
            Values = new List<List<Value>>() { new List<Value>() { 0 } };
        }

        public Variable(Value val, int i2 = 0, int i1 = 0)
        {
            Values = new List<List<Value>>();
            Set(i1, i2, val);
        }
        #endregion

        #region Methods
        public override bool CheckIndex(int i1, int i2)
        {
            return (Values.Count > i1 && Values[i1].Count > i2);
        }

        public override Value Get(int i1, int i2)
        {
            return Values[i1][i2];
        }

        public override void Set(int i1, int i2, Value val)
        {
            for (int i = Values.Count; i <= i1; i++)
                Values.Add(new List<Value>() { 0 });

            var list = Values[i1];

            for (int i = list.Count; i <= i2; i++)
                list.Add(Value.Zero);

            list[i2] = val;
        }
        #endregion

        #region IsReadOnly Property
        public override bool IsReadOnly { get { return false; } }
        #endregion
    }
}
