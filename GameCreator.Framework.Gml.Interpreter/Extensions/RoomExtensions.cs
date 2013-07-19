using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class RoomExtensions
    {
        public static void Init(this Room room)
        {
            if (room.CreationCode != null)
            {
                using (new InstanceScope(ExecutionContext.CreatePrivateInstance()))
                {
                    CodeUnit.Get(room).Run();
                }
            }
        }
    }
}
