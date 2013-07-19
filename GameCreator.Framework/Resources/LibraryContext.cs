using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void DefineVariable(string str)
        {
            (BuiltInVariables as List<string>).Add(str);
        }

        public bool IsBuiltIn(string varname)
        {
            return BuiltInVariables.Union(InstanceVariables).Contains(varname);
        }
    }
}
