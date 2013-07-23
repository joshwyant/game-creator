using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GameCreator.Framework
{
    public class Instance : IndexedResource
    {
        public static IndexedResourceManager<Instance> Manager
        {
            get
            {
                return LibraryContext.Current.Resources.Instances;
            }
        }

        [NoGmlExport]
        public int ObjectIndex { get; set; }

        protected internal Instance(ResourceContext context)
            : base(context) { }

        protected internal Instance(ResourceContext context, int objectIndex)
            : base(context)
        {
            ObjectIndex = objectIndex;

            context.Instances.Install(this);
        }

        protected internal Instance(ResourceContext context, int objectIndex, int index)
            : base(context)
        {
            ObjectIndex = objectIndex;

            if (index != 0)
                context.Instances.Install(this, index);
        }
    }
}
