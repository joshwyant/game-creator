using GameCreator.Resources.Api;

namespace GameCreator.Engine
{
    public class GameTimeline : INamedResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}