using System;
using System.Collections.Generic;
using GameCreator.Interpreter;

namespace GameCreator.Runtime
{
    public class IndexedResourceManager
    {
        long inds = 0;
        // The next index available, initially assigned by the IDE
        public long NextIndex { get{return inds;} set{inds = value;} }
        // Gets all of the indexed resources of this type in the game (e.g. rooms, sprites, objects, etc.)
        public Dictionary<long, IndexedResource> Resources = new Dictionary<long, IndexedResource>();
        public void Install(IndexedResource i)
        {
            i.Index = inds++;
            Resources.Add(i.Index, i);
            Env.DefineResourceIndex(i.Name, i.Index);
        }
        public void Install(IndexedResource i, long index)
        {
            i.Index = index;
            Resources.Add(index, i);
            Env.DefineResourceIndex(i.Name, index);
        }
    }
}
