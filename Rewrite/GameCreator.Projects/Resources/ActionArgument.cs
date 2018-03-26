using GameCreator.Resources.Api;

namespace GameCreator.Projects
{
    public struct ActionArgument
    {
        public ActionArgumentType Type;
        public string Value;

        public ActionArgument(ActionArgumentType type)
        {
            Type = type;
            Value = null;
        }
    }
}