using GameCreator.Resources.Api;

namespace GameCreator.Runtime.Api
{
    public interface IGameContext
    {
        IIndexedResourceManager<IInstance> Instances { get; }
    }
}