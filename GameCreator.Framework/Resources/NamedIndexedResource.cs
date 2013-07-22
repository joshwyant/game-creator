using System;
using System.Collections.Generic;

namespace GameCreator.Framework
{
    public class NamedIndexedResource : IndexedResource
    {
        public string Name { get; set; }

        protected internal NamedIndexedResource(ResourceContext context, string name)
            : base(context)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
