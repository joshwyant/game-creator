using System;
using System.Collections.Generic;

namespace GameCreator.Runtime
{
    public class IndexedResource
    {
        public long Index { get; set; }
        public string Name { get; set; }
        protected internal IndexedResource(string name) { Name = name;  }
    }
}
