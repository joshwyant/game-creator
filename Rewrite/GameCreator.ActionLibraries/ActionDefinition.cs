using GameCreator.Resources.Api;

namespace GameCreator.ActionLibraries
{
    public class ActionDefinition
    {
        public int GameMakerVersion { get; set; }
        public string Name { get; set; }
        public int ActionID { get; set; }
        public byte[] Image { get; set; }
        public bool Hidden { get; set; }
        public bool Advanced { get; set; }
        public bool RegisteredOnly { get; set; }
        public string Description { get; set; }
        public string ListText { get; set; }
        public string HintText { get; set; }
        public ActionKind Kind { get; set; }
        public ActionInterfaceKind InterfaceKind { get; set; }
        public bool IsQuestion { get; set; }
        public bool ShowApplyTo { get; set; }
        public bool ShowRelative { get; set; }
        public int ArgumentCount { get; set; }
        public ActionArgument[] Arguments { get; set; }
        public ActionExecutionType ExecutionType { get; set; }
        public string FunctionName { get; set; }
        public string Code { get; set; }

        public ActionDefinition()
        {
            
        }
        
        public ActionDefinition(string name, int id, byte[] image)
        {
            GameMakerVersion = 520;
            Name = name;
            ActionID = id;
            Image = image;
            Hidden = false;
            Advanced = false;
            RegisteredOnly = false;
            Description = string.Empty;
            ListText = string.Empty;
            HintText = string.Empty;
            Kind = ActionKind.Normal;
            InterfaceKind = ActionInterfaceKind.Normal;
            IsQuestion = false;
            ShowApplyTo = true;
            ShowRelative = true;
            ArgumentCount = 0;
            Arguments = new ActionArgument[8];
            for (var i = 0; i < 8; i++)
            {
                Arguments[i] = new ActionArgument();
            }
            ExecutionType = ActionExecutionType.None;
            FunctionName = string.Empty;
            Code = string.Empty;
        }

        public ActionDefinition(ActionLibrary library)
            : this($"Action {++library.LastActionId}", library.LastActionId, null)
        {
            
        }
    }
}