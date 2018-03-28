using System;
using System.Collections;
using System.Collections.Generic;

namespace GameCreator.Resources.Api
{
    public class IndexedResourceManager<T> : IIndexedResourceManager<T> where T : IIndexedResource
    {
        private readonly SortedDictionary<int, T> instances = new SortedDictionary<int, T>();
        private int nextIndex;

        public IndexedResourceManager(int startingIndex)
        {
            nextIndex = startingIndex;
        }

        public IndexedResourceManager(IEnumerable<T> initialItems, int startingIndex = 0)
            : this(startingIndex)
        {
            BaseAddRange(initialItems);
        }

        public bool ContainsKey(int id)
        {
            return instances.ContainsKey(id);
        }

        public int NextIndex
        {
            get => nextIndex;
            set
            {
                if (!TrySetNextIndex(value))
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool TrySetNextIndex(int index)
        {
            nextIndex = Math.Max(nextIndex, index);
            return index == nextIndex;
        }

        public int GenerateId()
        {
            return nextIndex++;
        }

        private int BaseAdd(T obj)
        {
            if (obj.Id == -1)
            {
                obj.Id = GenerateId();
            }
            else
            {
                TrySetNextIndex(obj.Id + 1);
            }
            instances[obj.Id] = obj;

            return obj.Id;
        }

        public virtual int Add(T obj)
        {
            return BaseAdd(obj);
        }

        public void AddRange(IEnumerable<T> objs)
        {
            foreach (var item in objs)
            {
                Add(item); // Uses virtual add
            }
        }

        private void BaseAddRange(IEnumerable<T> objs)
        {
            foreach (var item in objs)
            {
                BaseAdd(item); // Uses non-virtual add for constructor
            }
        }

        public T this[int id]
        {
            get => instances[id];
            set => instances[id] = value;
        }

        public virtual void Remove(int id)
        {
            instances.Remove(id);
        }

        public void RemoveRange(IEnumerable<int> items)
        {
            foreach (var item in items)
            {
                Remove(item);
            }
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return instances.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}