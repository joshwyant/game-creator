using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GameCreator.Framework
{
    public class LibraryContext
    {
        public static LibraryContext Current { get; set; }
        public Dictionary<string, BaseFunction> Functions { get; set; }
        public IEnumerable<string> BuiltInVariables { get; private set; }
        public Dictionary<int, ActionLibrary> Libraries { get; set; }
        public ResourceContext Resources { get; set; }
        public Dictionary<string, Value> Constants { get; set; }
        public IEnumerable<string> InstanceVariables { get; set; }
        public IInstanceFactory InstanceFactory { get; set; }

        public LibraryContext()
        {
            Libraries = new Dictionary<int, ActionLibrary>();
            Functions = new Dictionary<string, BaseFunction>();
            BuiltInVariables = new List<string>();
            InstanceVariables = new List<string>();
            Resources = new ResourceContext(this);
            Constants = new Dictionary<string, Value>();
        }

        public bool FunctionExists(string n)
        {
            return Functions.ContainsKey(n);
        }

        public ActionLibrary GetActionLibrary(int libid)
        {
            ActionLibrary lib;
            if (Libraries.TryGetValue(libid, out lib))
                return lib;
            lib = new ActionLibrary(this, libid);
            Libraries.Add(libid, lib);
            return lib;
        }

        public ActionDefinition GetAction(int libid, int actionid)
        {
            ActionDefinition a = null;
            GetActionLibrary(libid).Actions.TryGetValue(actionid, out a);
            return a;
        }

        public void DefineGlobalVariables(IEnumerable<string> str)
        {
            (BuiltInVariables as List<string>).AddRange(str);
        }

        public void DefineInstanceVariables(IEnumerable<string> str)
        {
            (InstanceVariables as List<string>).AddRange(str);
        }

        public bool IsBuiltIn(string varname)
        {
            return BuiltInVariables.Union(InstanceVariables).Contains(varname);
        }

        public void DefineConstants(Type t)
        {
            var fields = t.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly).Select(c => new { name = c.Name, value = new Value(c.GetRawConstantValue()) });

            foreach (var f in fields)
                Constants.Add(f.name, f.value);
        }

        public void ImportFunctions(IEnumerable<Type> types, Func<MethodInfo, string, BaseFunction> builder)
        {
            // Build the list of functions
            foreach (var mi in types.SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.Static)).Where(mi => mi.GetCustomAttributes(typeof(GmlFunctionAttribute), false).Any()))
            {
                var fn = (GmlFunctionAttribute)mi.GetCustomAttributes(typeof(GmlFunctionAttribute), false).Single();
                string name = string.IsNullOrEmpty(fn.Name) ? mi.Name : fn.Name;
                Functions.Add(name, builder(mi, name));
            }
        }

        public void ImportFunctionStubs(IEnumerable<Type> types)
        {
            ImportFunctions(types, 
                (m, n) => {
                    var parms = m.GetParameters();
                    var argc = parms.Length;
                    if (argc == 1 && parms.Any(p => p.GetCustomAttributes(typeof(ParamArrayAttribute), false).Any()))
                        argc = -1;

                    return new BaseFunction(n, argc);
            });
        }
    }
}
