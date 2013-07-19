using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    public static class InstanceExtensions
    {
        internal static void PerformEvent(this RuntimeInstance i, EventType ev, int num)
        {
            if (i.Destroyed)
                return;

            var obj = i.Context.Objects[i.ObjectIndex];

            if (obj.EventDefined(ev, num))
            {
                using (var scope = new InstanceScope(i, false))
                {
                    obj.Events[ev][num].Execute();
                }
            }
        }

        // Execute a string. The string is cached, and subsequent calls of Exec() with the same code string
        //  execute code that is already compiled and cached. Code that is executed from a known location, i.e., a script,
        //  is recommended to have its own local code unit, so it does not have to be looked up in a table.
        public static void Exec(this RuntimeInstance i, string s)
        {
            using (var scope = new InstanceScope(i))
            {
                CodeUnit.Get(s).Run();
            }
        }
    }
}
