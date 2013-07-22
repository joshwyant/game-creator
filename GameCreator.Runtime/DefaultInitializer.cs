using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.Runtime
{
    public class DefaultInitializer : LibraryInitializer
    {
        public IEnumerable<string> GlobalVariables
        {
            get
            {
                return new[] {
                    "argument", "argument0", "argument1", "argument2", "argument3", "argument4", "argument5", "argument6", "argument7", "argument8", "argument9", 
                    "argument10", "argument11", "argument12", "argument13", "argument14", "argument15", "argument_relative", "current_time"
                };
            }
        }

        public IEnumerable<KeyValuePair<string, Value>> Constants
        {
            get
            {
                return DefineConstants(typeof(Constants));
            }
        }

        public IEnumerable<string> InstanceVariables
        {
            get
            {
                return new[] {
                    "object_index", "id"
                };
            }
        }

        public IEnumerable<BaseFunction> ImportFunctions()
        {
            return Im
        }
    }
}
