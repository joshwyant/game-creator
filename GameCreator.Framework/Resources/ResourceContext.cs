using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework
{
    public class ResourceContext
    {
        public LibraryContext Context { get; set; }

        public IndexedResourceManager<Sprite> Sprites { get; set; }
        public IndexedResourceManager<Script> Scripts { get; set; }
        public IndexedResourceManager<Object> Objects { get; set; }
        public IndexedResourceManager<Room> Rooms { get; set; }
        public IndexedResourceManager<Instance> Instances { get; set; }

        public ResourceContext(LibraryContext context)
        {
            Context = context;
            Sprites = new IndexedResourceManager<Sprite>(this);
            Scripts = new IndexedResourceManager<Script>(this);
            Objects = new IndexedResourceManager<Object>(this);
            Rooms = new IndexedResourceManager<Room>(this);
            Instances = new IndexedResourceManager<Instance>(this, 100001);
        }

        public bool FunctionExists(string n)
        {
            return (Context.FunctionExists(n) || Scripts.Any(s => s.Value.Name == n));
        }
    }
}
