using System;
using System.Collections;
using System.Collections.Generic;

namespace GameCreator.Api.Resources
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
            foreach (var item in initialItems)
            {
                if (item.Id == -1)
                {
                    BaseAdd(item);
                }
                else
                {
                    this[item.Id] = item;
                    nextIndex = Math.Max(startingIndex, item.Id + 1);
                }
            }
        }

        public bool ContainsKey(int id)
        {
            return instances.ContainsKey(id);
        }

        public int NextIndex
        {
            get => nextIndex;
            set => SetNextIndex(value);
        }

        public void SetNextIndex(int nextIndex)
        {
            this.nextIndex = Math.Max(this.nextIndex, nextIndex);
        }

        public int GenerateId()
        {
            return nextIndex++;
        }

        private int BaseAdd(T obj)
        {
            int idx;
            instances[idx = nextIndex++] = obj;
            obj.Id = idx;
            return idx;
        }

        public virtual int Add(T obj)
        {
            return BaseAdd(obj);
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