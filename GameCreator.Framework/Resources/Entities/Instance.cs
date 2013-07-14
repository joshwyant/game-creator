using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GameCreator.Framework
{
    public class Instance : IndexedResource
    {
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

            context.Instances.Install(this, index);
        }
    }
}
