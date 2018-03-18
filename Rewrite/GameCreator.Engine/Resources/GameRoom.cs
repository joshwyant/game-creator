using System.Collections.Generic;
using System.Linq;

namespace GameCreator.Engine
{
    public abstract class GameRoom : IIndexedResource
    {
        public abstract IList<PredefinedInstance> PredefinedInstances { get; }

        public IList<PredefinedInstance> GetSortedPredefinedInstances()
        {
            return PredefinedInstances
                .OrderBy(i => i.GameObject.Depth)
                .ThenBy(i => i.Id)
                .ToList();
        }
        
        public HashSet<int> CreatedInstances { get; } = new HashSet<int>();
        
        public IGameContext Context { get; }
        public int Id { get; set; } = -1;
        public bool Persistent { get; set; }
        public int BackgroundColor { get; set; } = 0xA0A0A0;
        public int Width { get; set; } = 640;
        public int Height { get; set; } = 480;

        public GameRoom(IGameContext context)
        {
            Context = context;
        }

        public virtual void Creation()
        {
        }
    }
}