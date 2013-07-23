using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GameCreator.Framework
{
    public abstract class LibraryInitializer : ILibraryInitializer
    {
        public abstract IEnumerable<string> GlobalVariables { get; }

        public abstract IEnumerable<KeyValuePair<string, Value>> Constants { get; }

        public abstract IEnumerable<string> InstanceVariables { get; }

        public abstract IEnumerable<Type> FunctionLibraries { get; }

        protected IEnumerable<KeyValuePair<string, Value>> DefineConstants(Type t)
        {
            return t.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly).Select(c => new KeyValuePair<string, Value>(c.Name, new Value(c.GetRawConstantValue())));
        }

        public virtual BaseFunction TransformFunction(MethodInfo m, string n)
        {
            var parms = m.GetParameters();
            var argc = parms.Length;
            if (argc == 1 && parms.Any(p => p.GetCustomAttributes(typeof(ParamArrayAttribute), false).Any()))
                argc = -1;

            return new BaseFunction(n, argc);
        }


        public abstract IInstanceFactory CreateInstanceFactory(LibraryContext context);
    }
}
