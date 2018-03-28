namespace GameCreator.Resources.Api
{
    public interface INamedResourceManager<T> : IIndexedResourceManager<T> where T : INamedResource
    {
        T this[string name] { get; set; }
        bool ContainsKey(string name);
        string Prefix { get; }
        void Remove(string name);
        string GenerateName();
    }
}