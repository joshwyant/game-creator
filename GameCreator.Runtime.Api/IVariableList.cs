namespace GameCreator.Runtime.Api
{
    public interface IVariableList
    {
        Variant this[string name] { get; set; }
        Variant this[string name, int i1] { get; set; }
        Variant this[string name, int i1, int i2] { get; set; }
        bool Exists(string name);
        bool IsBuiltIn(string name);
        IVariable GetVariable(string name);
    }
}