using App.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Resources
{
    public class AppAction : IAppAction
    {
        public int ActionId { get; set; }
        public int AppliesToObjectIndex { get; set; }
        public bool AppliesToSomething { get; set; }
        public List<ActionArgument> Arguments { get; set; }
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
    }
}
