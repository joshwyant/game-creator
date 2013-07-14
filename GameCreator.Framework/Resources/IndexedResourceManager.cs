using System;
using System.Collections.Generic;
using GameCreator.Framework;

namespace GameCreator.Framework
{
    public class IndexedResourceManager<T> : Dictionary<int, T> where T: IndexedResource
    {
        public ResourceContext Context { get; set; }

        // The next index available, initially assigned by the IDE
        public int NextIndex { get; set; }

        // Gets all of the indexed resources of this type in the game (e.g. rooms, sprites, objects, etc.)
        public Dictionary<int, T> Resources { get; set; }

        internal IndexedResourceManager(ResourceContext context, int initialIndex)
        {
            Context = context;
            NextIndex = initialIndex;
        }

        internal IndexedResourceManager(ResourceContext context)
            : this(context, 0) { }

        public void Install(T i)
        {
            i.Id = NextIndex++;
            Add(i.Id, i);
        }

        public void Install(T i, int index)
        {
            i.Id = index;

            if (index >= NextIndex)
                NextIndex = index + 1;

            Add(index, i);
        }
    }
}
