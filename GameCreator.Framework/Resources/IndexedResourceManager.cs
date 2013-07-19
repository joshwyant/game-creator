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
        public Dictionary<int, T> Resources { get { return this; } }

        internal IndexedResourceManager(ResourceContext context, int initialIndex)
        {
            context.Managers.Add(typeof(T), this);
            Context = context;
            NextIndex = initialIndex;
        }

        internal IndexedResourceManager(ResourceContext context)
            : this(context, 0) { }

        public void Install(T i, int index = -1)
        {
            i.Id = index == -1 ? NextIndex++ : index;

            if (index >= NextIndex)
                NextIndex = index + 1;

            Add(index, i);
        }
    }
}
