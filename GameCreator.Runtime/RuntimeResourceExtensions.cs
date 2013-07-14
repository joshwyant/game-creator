using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.Runtime
{
    public static class ResourceExtensions
    {
        public static RuntimeInstance DefineRuntime(this IndexedResourceManager<Instance> manager, int objectIndex, int index)
        {
            return new RuntimeInstance(manager.Context, objectIndex, index);
        }

        public static RuntimeInstance DefineRuntime(this IndexedResourceManager<Instance> manager, int objectIndex)
        {
            return new RuntimeInstance(manager.Context, objectIndex);
        }

        public static RuntimeInstance DefineRuntime(this IndexedResourceManager<Instance> manager)
        {
            return new RuntimeInstance(manager.Context);
        }
    }
}
