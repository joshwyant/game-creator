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
        public int Id { get; set; }
        public bool Persistent { get; set; }

        public GameRoom(IGameContext context)
        {
            Context = context;
        }

        public virtual void Creation()
        {
        }
    }
}