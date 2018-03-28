using GameCreator.Resources.Api;

namespace GameCreator.Runtime.Api
{
    public interface IInstance : IIndexedResource
    {
        IVariableList Variables { get; }
        int ObjectIndex { get; }
    }
}