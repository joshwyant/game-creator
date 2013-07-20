using System.IO;
namespace GameCreator.Framework
{
    // the 'resource representation' of a script.
    // as scripts are not allowed to be created on the fly, the script must have an IDE-assigned index.
    public class Script : NamedIndexedResource, IGml
    {
        public static IndexedResourceManager<Script> Manager
        {
            get
            {
                return LibraryContext.Current.Resources.Scripts;
            }
        }

        public string Code { get; set; }

        internal Script(ResourceContext context)
            : base(context, null)
        {
            context.Scripts.Install(this);

            Code = string.Empty;
            Name = string.Format("script{0}", Id);
        }

        internal Script(ResourceContext context, string name, string code)
            : base(context, name)
        {
            context.Scripts.Install(this);
            Code = code;
        }

        internal Script(ResourceContext context, string name, int index, string code)
            : base(context, name)
        {
            context.Scripts.Install(this, index);
            Code = code;
        }

        public TextReader GetCodeReader()
        {
            return new StringReader(Code);
        }

        public FunctionDelegate ExecutionDelegate { get; set; }
    }
}
