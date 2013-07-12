using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class RoomExtensions
    {
        Dictionary<Room, CodeUnit> InitializationCode { get; set; }

        public void Init(this Room room)
        {
            if (room.CreationCode != null)
            {
                CodeUnit cu;
                InitializationCode.TryGetValue(room, out cu);
                if (cu == null)
                    cu = new CodeUnit(room.CreationCode);
                Instance current = ExecutionContext.Current;
                ExecutionContext.Current = ExecutionContext.CreatePrivateInstance();
                ExecutionContext.Enter();
                cu.Run();
                ExecutionContext.Leave();
                ExecutionContext.Current = current;
            }
        }
    }
}
