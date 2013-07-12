using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework
{
    public class LibraryContext
    {
        public Dictionary<string, BaseFunction> Functions { get; set; }
        public IEnumerable<string> BuiltInVariables { get; set; }
        public Dictionary<int, ActionLibrary> Libraries { get; set; }

        public LibraryContext()
        {
            Libraries = new Dictionary<int, ActionLibrary>();
            Functions = new Dictionary<string, BaseFunction>();
            BuiltInVariables = new List<string>();
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
        // context.GetActionLibrary(1).DefineAction(100, normal, false, "action_xx", null, {expr, menu, object});
        public void DefineAction(int actionid, ActionKind kind, ActionExecutionType execution, bool question, string func, string code, ActionArgumentType[] args) { if (!Actions.ContainsKey(actionid)) Actions.Add(actionid, new ActionDefinition(kind, execution, question, func, code, args)); }

        public ActionDefinition GetAction(int libid, int actionid)
        {
            ActionDefinition a = null;
            GetActionLibrary(libid).Actions.TryGetValue(actionid, out a);
            return a;
        }
    }
}
