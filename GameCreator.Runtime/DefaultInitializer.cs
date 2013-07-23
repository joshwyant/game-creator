using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;
using System.Reflection;

namespace GameCreator.Runtime
{
    public class DefaultInitializer : LibraryInitializer
    {
        public override IEnumerable<string> GlobalVariables
        {
            get
            {
                return new[] {
                    "argument", "argument0", "argument1", "argument2", "argument3", "argument4", "argument5", "argument6", "argument7", "argument8", "argument9", 
                    "argument10", "argument11", "argument12", "argument13", "argument14", "argument15", "argument_relative", "current_time",
                };
            }
        }

        public override IEnumerable<KeyValuePair<string, Value>> Constants
        {
            get
            {
                return DefineConstants(typeof(Constants));
            }
        }

        public override IEnumerable<string> InstanceVariables
        {
            get
            {
                return new[] {
                    "object_index", "id",
                };
            }
        }

        public override IEnumerable<Type> FunctionLibraries
        {
            get
            {
                var asm = Assembly.Load("GameCreator.Runtime.Library");
                return new[] { 
                    asm.GetType("GameCreator.Runtime.Library.GmlFunctions"),
                };
            }
        }

        public override IInstanceFactory CreateInstanceFactory(LibraryContext context)
        {
            return new DefaultInstanceFactory(context);
        }

        public override void PerformEvent(Instance e, EventType et, int num)
        {
            throw new NotImplementedException();
        }
    }
}
