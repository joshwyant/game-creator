using System.Collections.Generic;

namespace GameCreator.Resources.Api
{
    public interface IIndexedResourceManager<T> : IEnumerable<T> where T : IIndexedResource
    {
        bool ContainsKey(int id);
        bool TrySetNextIndex(int nextIndex);
        int GenerateId();
        int Add(T obj);
        void AddRange(IEnumerable<T> objs);
        T this[int id] { get; set; }
        void Remove(int id);
        void RemoveRange(IEnumerable<int> items);
    }
}