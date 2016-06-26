using App.Contracts;
using System.Collections.Generic;

namespace App.Resources
{
    public class IndexedResourceManager<T> : Dictionary<int, T>, IIndexedResourceManager<T>
        where T : IIndexedResource
    {
        public int NextIndex { get; set; }

        public T Add()
        {
            var index = NextIndex++;

            T resource = AppRepository.Container.GetInstance<T>();

            (resource as NamedResource).Index = index;

            Add(index, resource);

            return resource;
        }
    }
}
