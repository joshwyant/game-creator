using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameCreator.Resources.Api
{
    public class WindowedIndexedResourceManager<T> : IIndexedResourceManager<T> where T : IIndexedResource
    {
        public IIndexedResourceManager<T> Parent { get; }
        public HashSet<int> OwnedResources { get; } = new HashSet<int>();
        
        public WindowedIndexedResourceManager(IIndexedResourceManager<T> parent)
        {
            Parent = parent;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return Parent.Where(p => OwnedResources.Contains(p.Id)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool ContainsKey(int id)
        {
            return OwnedResources.Contains(id);
        }

        public bool TrySetNextIndex(int nextIndex)
        {
            return Parent.TrySetNextIndex(nextIndex);
        }

        public int GenerateId()
        {
            return Parent.GenerateId();
        }

        public int Add(T obj)
        {
            var id = Parent.Add(obj);
            OwnedResources.Add(id);
            return id;
        }

        public void AddRange(IEnumerable<T> objs)
        {
            foreach (var obj in objs)
            {
                Add(obj);
            }
        }

        public T this[int id]
        {
            get
            {
                if (!ContainsKey(id))
                {
                    throw new KeyNotFoundException();
                }
                return Parent[id];
            }
            set
            {
                OwnedResources.Add(id);
                Parent[id] = value;
            }
        }

        public void Remove(int id)
        {
            if (!ContainsKey(id))
            {
                throw new KeyNotFoundException();
            }

            OwnedResources.Remove(id);
            Parent.Remove(id);
        }

        public void RemoveRange(IEnumerable<int> items)
        {
            foreach (var item in items)
            {
                Remove(item);
            }
        }
    }
}