using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework
{
    public abstract class IndexedResource
    {
        [NoGmlExport]
        public ResourceContext Context { get; set; }
        [NoGmlExport]
        public int Id { get; set; }

        protected internal IndexedResource(ResourceContext context)
        {
            Context = context;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;

            var other = obj as IndexedResource;

            return Id == other.Id;
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
