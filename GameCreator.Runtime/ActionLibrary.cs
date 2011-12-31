using System.Collections.Generic;

namespace GameCreator.Runtime
{
    public class ActionLibrary
    {

      #region Publicly accessible methods
        // A game calls GameCreator.Runtime.ActionLibrary.Define() to define actions for a library with the given id.
        public static ActionLibrary Define(int libid)
        {
            ActionLibrary lib;
            if (Libraries.TryGetValue(libid, out lib))
                return lib;
            lib = new ActionLibrary(libid);
            Libraries.Add(libid, lib);
            return lib;
        }
        // GameCreator.Runtime.ActionLibrary.Define(1).DefineAction(100, normal, false, "action_xx", null, {expr, menu, object});
        public void DefineAction(int actionid, ActionKind kind, ActionExecutionType execution, bool question, string func, string code, ActionArgumentType[] args) { if (!Actions.ContainsKey(actionid)) Actions.Add(actionid, new ActionDefinition(kind, execution, question, func, code, args)); }
      #endregion

      #region Internal Methods
        // foreach actions in eventdefinition
        //   add GetAction(libid, actionid) to event
        internal static ActionDefinition GetAction(int libid, int actionid)
        {
            ActionDefinition a = null;
            Define(libid).Actions.TryGetValue(actionid, out a);
            return a;
        }
      #endregion

      #region private methods
        static Dictionary<int, ActionLibrary> Libraries = new Dictionary<int, ActionLibrary>();
        Dictionary<int, ActionDefinition> Actions = new Dictionary<int, ActionDefinition>();
        int ID { get; set; }
        ActionLibrary(int id) { ID = id; }
      #endregion

    }
}
