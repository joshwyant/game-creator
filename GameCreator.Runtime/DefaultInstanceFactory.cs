using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.Runtime
{
    public class DefaultInstanceFactory : IInstanceFactory
    {
        public LibraryContext Context { get; set; }

        public DefaultInstanceFactory(LibraryContext context)
        {
            Context = context;
        }

        public virtual Instance CreatePrivateInstance()
        {
            return new RuntimeInstance(Context.Resources);
        }

        public virtual Instance CreateInstance(int object_index)
        {
            return new RuntimeInstance(Context.Resources, object_index, -1);
        }

        public virtual Instance CreateInstance(int object_index, int id)
        {
            return new RuntimeInstance(Context.Resources, object_index, id);
        }

        public IDictionary<int, Instance> Instances
        {
            get { return Context.Resources.Instances; }
        }

        public void DestroyInstance(int id)
        {
            throw new NotImplementedException();
        }

        public void DestroyInstances(Func<Instance, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
