using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.Runtime
{
    public abstract class GetSetValue : IGetSet<Value>
    {
        #region Abstract methods
        public abstract Value Get(int i1, int i2);

        public abstract void Set(int i1, int i2, Value value);

        public abstract bool CheckIndex(int i1, int i2);

        public abstract bool IsReadOnly { get; }
        #endregion

        #region Helper Access Properties
        public Value Value
        {
            get
            {
                return Get(0, 0);
            }
            set
            {
                Set(0, 0, value);
            }
        }
        public Value this[int i1, int i2]
        {
            get
            {
                return Get(i1, i2);
            }
            set
            {
                Set(i1, i2, value);
            }
        }
        public Value this[int index]
        {
            get
            {
                return Get(0, index);
            }
            set
            {
                Set(0, index, value);
            }
        }
        #endregion
    }
}
