using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace GameCreator.Framework
{
    public class Room : NamedIndexedResource, IGml
    {
        public static IndexedResourceManager<Room> Manager
        {
            get
            {
                return LibraryContext.Current.Resources.Rooms;
            }
        }

        public string CreationCode { get; set; }

        internal Room(ResourceContext context)
            : base(context, null)
        {
            context.Rooms.Install(this);

            Name = string.Format("room{0}", Id);
        }

        internal Room(ResourceContext context, string name)
            : base(context, name)
        {
            context.Rooms.Install(this);
        }

        internal Room(ResourceContext context, string name, int index)
            : base(context, name)
        {
            context.Rooms.Install(this, index);
        }

        public TextReader GetCodeReader()
        {
            return new StringReader(CreationCode);
        }
    }
}
