using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GameCreator.Framework
{
    public abstract class LibraryInitializer : ILibraryInitializer
    {
        protected IEnumerable<KeyValuePair<string, Value>> DefineConstants(Type t)
        {
            return t.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly).Select(c => new KeyValuePair<string, Value>(c.Name, new Value(c.GetRawConstantValue())));
        }

        protected IEnumerable<BaseFunction> ImportFunctions(IEnumerable<Type> types, Func<MethodInfo, string, BaseFunction> builder)
        {
            // Build the list of functions
            foreach (var mi in types.SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.Static)).Where(mi => mi.GetCustomAttributes(typeof(GmlFunctionAttribute), false).Any()))
            {
                var fn = (GmlFunctionAttribute)mi.GetCustomAttributes(typeof(GmlFunctionAttribute), false).Single();
                string name = string.IsNullOrEmpty(fn.Name) ? mi.Name : fn.Name;
                yield return builder(mi, name);
            }
        }

        protected IEnumerable<BaseFunction> ImportFunctionStubs(IEnumerable<Type> types)
        {
            return ImportFunctions(types,
                (m, n) =>
                {
                    var parms = m.GetParameters();
                    var argc = parms.Length;
                    if (argc == 1 && parms.Any(p => p.GetCustomAttributes(typeof(ParamArrayAttribute), false).Any()))
                        argc = -1;

                    return new BaseFunction(n, argc);
                });
        }

        public abstract IEnumerable<string> GlobalVariables { get; }

        public abstract IEnumerable<KeyValuePair<string, Value>> Constants { get; }

        public abstract IEnumerable<string> InstanceVariables { get; }

        public abstract IEnumerable<BaseFunction> ImportFunctions();
    }
}
