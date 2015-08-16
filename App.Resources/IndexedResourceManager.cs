using App.Contracts;
using System.Collections.Generic;

namespace App.Resources
{
    public class IndexedResourceManager<T> : Dictionary<int, T>, IIndexedResourceManager<T>
        where T : IIndexedResource
    {
        public int NextIndex { get; set; }
    }
}
