using System.IO;
namespace GameCreator.Framework
{
    public class Action : IGml
    {
        public ResourceContext Context { get; set; }
        public ActionDefinition Definition { get; private set; }
        public string[] Arguments { get; private set; }
        public int AppliesTo { get; set; }
        public bool Relative { get; set; }
        public bool Not { get; set; }
        public string Code { get; set; }

        public Action(ResourceContext context, int libid, int id, string[] args, int appliesto, bool relative, bool not)
        {
            Context = context;
            Definition = context.Context.GetAction(libid, id);
            Arguments = args;
            AppliesTo = appliesto;
            Relative = relative;
            Not = not;
            if (Definition.Kind == ActionKind.Code)
                Code = Arguments[0];
            else if (Definition.Kind == ActionKind.Variable)
                Code = string.Format(Relative ? "{0} += {1}" : "{0} = {1}", Arguments[0], Arguments[1]);
        }

        public TextReader GetCodeReader()
        {
            return new StringReader(Code);
        }
    }
}
