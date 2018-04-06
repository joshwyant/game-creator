using System;

namespace GameCreator.Resources.Api
{
    public interface IResourceTable
    {
        void RegisterResource(INamedResource r);
        void RemoveResource<T>(T r) where T : INamedResource;
        INamedResource OfType<T>(string name) where T : INamedResource;
    }
}