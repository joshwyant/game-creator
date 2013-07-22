using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GameCreator.Framework
{
    public interface ILibraryInitializer
    {
        IEnumerable<string> GlobalVariables { get; }
        IEnumerable<KeyValuePair<string, Value>> Constants { get; }
        IEnumerable<string> InstanceVariables { get; }
        IEnumerable<Type> FunctionLibraries { get; }  
        BaseFunction TransformFunction(MethodInfo fn, string name);
    }
}
