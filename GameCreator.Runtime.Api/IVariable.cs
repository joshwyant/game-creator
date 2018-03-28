namespace GameCreator.Runtime.Api
{
    public interface IVariable
    {
        Variant Value { get; set; }
        Variant this[int i1] { get; set; }
        Variant this[int i1, int i2] { get; set; }
    }
}