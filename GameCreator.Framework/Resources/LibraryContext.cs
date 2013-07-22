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
        public Dictionary<string, Value> Constants { get; set; }
        public IEnumerable<string> InstanceVariables { get; set; }

        public IInstanceFactory InstanceFactory { get; set; }

        public ResourceContext Resources { get; set; }

        public Action<Instance, EventType, int> PerformEvent { get; set; }

        public LibraryContext()
            : this(null) { }

        public LibraryContext(ILibraryInitializer initializer)
        {
            Initialize(initializer);
        }

        public void Initialize(ILibraryInitializer initializer)
        {

            Libraries = new Dictionary<int, ActionLibrary>();
            Functions = new Dictionary<string, BaseFunction>();
            BuiltInVariables = new List<string>();
            InstanceVariables = new List<string>();
            Constants = new Dictionary<string, Value>();

            Resources = Resources ?? new ResourceContext(this);

            if (initializer != null)
            {
                var funcs = initializer.ImportFunctions();
                foreach (var f in funcs)
                    Functions.Add(f.Name, f);

                (InstanceVariables as List<string>).AddRange(initializer.InstanceVariables);
                (BuiltInVariables as List<string>).AddRange(initializer.GlobalVariables);

                foreach (var c in initializer.Constants)
                    Constants.Add(c.Key, c.Value);
            }
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

        public bool IsBuiltIn(string varname)
        {
            return BuiltInVariables.Union(InstanceVariables).Contains(varname);
        }
    }
}
