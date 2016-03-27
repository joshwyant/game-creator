using System.Collections.Generic;
using GameCreator.Resources.Api;

namespace GameCreator.Projects
{
    public class ActionEntry
    {
        public int ActionId { get; set; }
        public int AppliesToObjectIndex { get; set; }
        public bool AppliesToSomething { get; set; }
        public string[] Arguments { get; set; }
        public int ArgumentsUsed { get; set; }
        public string Code { get; set; }
        public string FunctionName { get; set; }
        public bool IsQuestion { get; set; }
        public ActionKind Kind { get; set; }
        public int LibraryId { get; set; }
        public bool MayBeRelative { get; set; }
        public bool Not { get; set; }
        public bool Relative { get; set; }
        public ActionExecutionType Type { get; set; }
        public ActionArgumentType[] ArgumentTypes { get; set; }
        public int Version { get; set; }
    }
}