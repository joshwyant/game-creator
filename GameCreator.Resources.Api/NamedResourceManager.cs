using System.Collections.Generic;
using System.Linq;

namespace GameCreator.Resources.Api
{
    public abstract class NamedResourceManager<T> 
        : IndexedResourceManager<T>, INamedResourceManager<T> 
        where T : INamedResource
    {
        private Dictionary<string, T> _nameLookup;
        
        public NamedResourceManager(int startingIndex) : base(startingIndex)
        {
            _nameLookup = new Dictionary<string, T>();
        }

        public NamedResourceManager(T[] initialItems, int startingIndex = 0) : base(initialItems, startingIndex)
        {
            _nameLookup = initialItems.ToDictionary(i => i.Name, i => i);
        }

        public override int Add(T obj)
        {
            var idx = base.Add(obj);
            if (string.IsNullOrEmpty(obj.Name))
            {
                obj.Name = GenerateName();
            }

            return idx;
        }

        public T this[string name]
        {
            get => _nameLookup[name];
            set
            {
                Add(value);
                _nameLookup[name] = value;
            }
        }

        public bool ContainsKey(string name) => _nameLookup.ContainsKey(name);

        public abstract string Prefix { get; }

        public override void Remove(int id)
        {
            var obj = this[id];
            _nameLookup.Remove(obj.Name);
            base.Remove(id);
        }

        public virtual void Remove(string name)
        {
            var obj = _nameLookup[name];
            _nameLookup.Remove(name);
            base.Remove(obj.Id);
        }

        public string GenerateName()
        {
            return Prefix + NextIndex;
        }
    }
}