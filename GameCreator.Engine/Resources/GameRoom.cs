using System.Collections.Generic;
using System.Linq;
using GameCreator.Resources.Api;

namespace GameCreator.Engine
{
    public abstract class GameRoom : IIndexedResource
    {
        public GameRoom() {}
        public abstract IList<PredefinedInstance> PredefinedInstances { get; }

        public IList<PredefinedInstance> GetSortedPredefinedInstances()
        {
            return PredefinedInstances
                .OrderBy(i => i.GameObject.Depth)
                .ThenBy(i => i.Id)
                .ToList();
        }
        
        public HashSet<int> CreatedInstances { get; } = new HashSet<int>();
        
        public GameContext Context { get; }
        public int Id { get; set; } = -1;
        public bool Persistent { get; set; }
        public int BackgroundColor { get; set; } = 0xA0A0A0;
        public int Width { get; set; } = 640;
        public int Height { get; set; } = 480;

        public GameRoom(GameContext context)
        {
            Context = context;
        }

        public virtual void Creation()
        {
        }
    }
}