using GameCreator.Framework.Gml;

namespace GameCreator.Framework
{
    class ActionDefinition
    {
        public ActionKind Kind { get; private set; }
        public ActionExecutionType ExecutionType { get; private set; }
        public string FunctionName { get; private set; }
        public CodeUnit Code { get; private set; }
        public ActionArgumentType[] Arguments { get; private set; }
        public bool IsQuestion { get; private set; }
        public ActionDefinition(ActionKind kind, ActionExecutionType exec, bool question, string funcname, string code, ActionArgumentType[] args)
        {
            Kind = kind;
            ExecutionType = exec;
            IsQuestion = question;
            FunctionName = funcname;
            if (!string.IsNullOrEmpty(code))
            {
                Code = new CodeUnit(code);
                Code.Compile();
            }
            Arguments = args;
        }
    }
}