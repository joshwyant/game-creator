using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Runtime
{
    public interface IGetSet<T>
    {
        T Get(int i1, int i2);
        void Set(int i1, int i2, T value);
        bool CheckIndex(int i1, int i2);
        bool IsReadOnly { get; }
    }
}
