using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework
{
    public interface IInstanceFactory
    {
        Instance CreatePrivateInstance();
        Instance CreateInstance(int object_index);
        Instance CreateInstance(int object_index, int id);
        IDictionary<int, Instance> Instances { get; }
        void DestroyInstance(int id);
        void DestroyInstances(Func<Instance, bool> predicate);
    }
}
