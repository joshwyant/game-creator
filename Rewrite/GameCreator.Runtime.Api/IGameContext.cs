namespace GameCreator.Runtime.Api
{
    public interface IGameContext
    {
        IIndexedResourceManager<IInstance> Instances { get; }
    }
}