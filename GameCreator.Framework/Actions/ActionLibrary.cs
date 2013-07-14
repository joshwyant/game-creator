using System.Collections.Generic;

namespace GameCreator.Framework
{
    public class ActionLibrary
    {
        public LibraryContext Context { get; set; }

        internal Dictionary<int, ActionDefinition> Actions = new Dictionary<int, ActionDefinition>();

        int Id { get; set; }

        internal ActionLibrary(LibraryContext context, int id)
        {
            Context = context;
            Id = id;
        }

        // context.GetActionLibrary(1).DefineAction(100, normal, false, "action_xx", null, {expr, menu, object});
        public void DefineAction(int actionid, ActionKind kind, ActionExecutionType execution, bool question, string func, string code, ActionArgumentType[] args)
        {
            if (!Actions.ContainsKey(actionid))
                Actions.Add(actionid, new ActionDefinition(kind, execution, question, func, code, args));
        }
    }
}
