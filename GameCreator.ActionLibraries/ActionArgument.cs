using GameCreator.Api.Resources;

namespace GameCreator.ActionLibraries
{
    public class ActionArgument
    {
        public ActionArgument()
        {
            Caption = string.Empty;
            Type = ActionArgumentType.Expression;
            DefaultValue = "0";
            Menu = "item1|item2";
        }
        public string Caption { get; set; }
        public ActionArgumentType Type { get; set; }
        public string DefaultValue { get; set; }
        public string Menu { get; set; }
    }
}