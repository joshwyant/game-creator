using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GameCreator.Framework
{
    public class Room : IndexedResource
    {
        public static IndexedResourceManager Manager = new IndexedResourceManager();
        CodeUnit creationcode;
        public string CreationCode { get { return creationcode.Code; } set { creationcode = new CodeUnit(value); } }
        public void Init()
        {
            if (creationcode != null)
            {
                Instance current = ExecutionContext.Current;
                ExecutionContext.Current = ExecutionContext.CreatePrivateInstance();
                ExecutionContext.Enter();
                creationcode.Run();
                ExecutionContext.Leave();
                ExecutionContext.Current = current;
            }
        }
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
    }
}
