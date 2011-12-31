namespace GameCreator.Runtime
{
    // the 'resource representation' of a script.
    // as scripts are not allowed to be created on the fly, the script must have an IDE-assigned index.
    public class Script : IndexedResource
    {
        public static IndexedResourceManager Manager = new IndexedResourceManager();
        public string Code { get; private set; }
        internal GameCreator.Runtime.Interpreter.ScriptFunction CompiledScript { get; set; }
        Script(string name, int index, string code) : base(name) { Manager.Install(this, index); Code = code; }
        public static Script Define(string name, int index, string code)
        {
            return new Script(name, index, code);
        }
    }
}
