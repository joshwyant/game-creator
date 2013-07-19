using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GameCreator.Framework
{
    public class ResourceContext
    {
        public LibraryContext Context { get; set; }

        public Dictionary<Type, IDictionary> Managers { get; set; }
        public IndexedResourceManager<Sprite> Sprites { get; set; }
        public IndexedResourceManager<Script> Scripts { get; set; }
        public IndexedResourceManager<Object> Objects { get; set; }
        public IndexedResourceManager<Room> Rooms { get; set; }
        public IndexedResourceManager<Instance> Instances { get; set; }
        public Dictionary<string, Value> Constants { get; set; }

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

        public Value GetNamedValue(string name)
        {
            return Managers.Values.SelectMany(m => m.Values.OfType<NamedIndexedResource>())
                   .Where(o => o.Name == name)
                       .Select(o => new Value(o.Id))
                   .Union(Constants.Where(c => c.Key == name)
                       .Select(c => c.Value))
                   .Union(Context.Constants.Where(c => c.Key == name)
                       .Select(c => c.Value))
                   .FirstOrDefault();
        }

        public BaseFunction GetFunction(string str)
        {
            return Scripts.Values.Cast<BaseFunction>().Union(Context.Functions.Values).FirstOrDefault(f => f.Name == str);
        }

        public void DefineConstant(string name, Value val)
        {
            if (Constants.ContainsKey(name))
                Constants.Remove(name);
            Constants.Add(name, val);
        }
    }
}
