using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Library
{
    internal static partial class GMLFunctions
    {
        /*
        [GMLFunction(-1)]
        public static Value f(params Value[] args)
        {
           return new Value();
        }
        */
        // non-gml function; does not perform create event
        public static RuntimeInstance CreateInstance(int id, double x, double y)
        {
            IndexedResource res;
            if (!Object.Manager.Resources.TryGetValue(id, out res))
                return null;
            Object o = res as Object;
            RuntimeInstance e = ExecutionContext.CreateInstance();
            e.sprite_index.value = o.SpriteIndex;
            e.xstart.value = x;
            e.ystart.value = y;
            e.x.value = x;
            e.y.value = y;
            e.object_index.value = id;
            return e;
        }
        [GMLFunction(3)]
        public static Value instance_create(params Value[] args)
        {
            int object_index = args[2];
            RuntimeInstance e = CreateInstance(object_index, args[0], args[1]);
            if (e != null)
                (Object.Manager.Resources[object_index] as Object).PerformEvent(e, EventType.Create, 0);
            return e.id.value;
        }
    }
}
