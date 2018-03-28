namespace GameCreator.Resources.Api
{
    public interface INamedResource : IIndexedResource
    {
        string Name { get; set; }
    }
}