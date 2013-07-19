using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.Runtime.Library
{
    internal static partial class GMLFunctions
    {
        /*
        [GmlFunction]
        public static Value f(params Value[] args)
        {
           return new Value();
        }
        */
        // non-gml function; does not perform create event
        public static RuntimeInstance CreateInstance(int id, double x, double y)
        {
            Framework.Object o;
            if (!LibraryContext.Current.Resources.Objects.TryGetValue(id, out o))
                return null;
            var values = new[] {
                new KeyValuePair<string, Value>("sprite_index", o.SpriteIndex),
                new KeyValuePair<string, Value>("xstart", x),
                new KeyValuePair<string, Value>("ystart", y),
                new KeyValuePair<string, Value>("x", x),
                new KeyValuePair<string, Value>("y", y)
            };

            return LibraryContext.Current.InstanceFactory.CreateInstance(o.Id, values) as RuntimeInstance;
        }

        [GmlFunction]
        public static int instance_create(double x, double y, int object_index)
        {
            var e = CreateInstance(object_index, x, y);
            LibraryContext.Current.Resources.Objects[object_index].PerformEvent(e, EventType.Create, 0);
            return e.id;
        }
    }
}
