using System.Collections.Generic;

namespace GameCreator.Api.Resources
{
    public interface IIndexedResourceManager<T> : IEnumerable<T> where T : IIndexedResource
    {
        bool ContainsKey(int id);
        void SetNextIndex(int nextIndex);
        int GenerateId();
        int Add(T obj);
        T this[int id] { get; set; }
        void Remove(int id);
    }
}