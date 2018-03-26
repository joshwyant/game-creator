using GameCreator.Resources.Api;

namespace GameCreator.Projects
{
    public class InstanceResource : IIndexedResource
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int ObjectIndex { get; set; }
        public string CreationCode { get; set; }
        public bool Locked { get; set; }
    }
}