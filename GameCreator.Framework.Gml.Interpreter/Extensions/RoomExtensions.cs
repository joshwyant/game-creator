using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Runtime;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class RoomExtensions
    {
        public static void Init(this Room room)
        {
            if (room.CreationCode != null)
            {
                using (new InstanceScope(LibraryContext.Current.InstanceFactory.CreatePrivateInstance() as RuntimeInstance))
                {
                    CodeUnit.Get(room).Run();
                }
            }
        }
    }
}
