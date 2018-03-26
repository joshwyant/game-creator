using GameCreator.Resources.Api;

namespace GameCreator.Projects
{
    public abstract class BaseResource : IIndexedResource
    {
        public int Id { get; set; } = -1;
        public string Name { get; set; }

        public BaseResource(string name)
        {
            Name = name;
        }
    }
}