using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Dynamic
{
    internal interface IMemberAccessor<T>
    {
        T Get(object obj, int i1, int i2);
        void Set(object obj, int i1, int i2, T value);
        bool CheckIndex(object obj, int i1, int i2);
        bool IsReadOnly(object obj);
    }
}
