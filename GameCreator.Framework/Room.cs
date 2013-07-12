using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GameCreator.Framework
{
    public class Room : IndexedResource
    {
        public static IndexedResourceManager Manager = new IndexedResourceManager();
        public string CreationCode { get; set; }
        public void Cleanup()
        {
        }
        Room(string name) : base(name) { Manager.Install(this); }
        Room(string name, int index) : base(name) { Manager.Install(this, index); }
        public static Room Define(string name)
        {
            return new Room(name);
        }
        public static Room Define(string name, int index)
        {
            return new Room(name, index);
        }

        public override int GetHashCode()
        {
            return Index;
        }
    }
}
