using GameCreator.Api.Resources;

namespace GameCreator.Api.Runtime
{
    public interface IGameContext
    {
        IIndexedResourceManager<IInstance> Instances { get; }
    }
}