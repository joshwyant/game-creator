using System.Collections.Generic;
using System.Linq;
using GameCreator.Resources.Api;
using GameCreator.Runtime.Api;

namespace GameCreator.Engine
{
    public abstract class GameRoom : INamedResource
    {
        public abstract IList<PredefinedInstance> PredefinedInstances { get; }

        public IList<PredefinedInstance> GetSortedPredefinedInstances()
        {
            return PredefinedInstances
                .OrderBy(i => i.GameObject.Depth)
                .ThenBy(i => i.Id)
                .ToList();
        }
        
        public WindowedIndexedResourceManager<IInstance> RoomManagedInstances { get; }
        public WindowedIndexedResourceManager<IInstance> DeactivatedInstances { get; }
        
        public GameContext Context { get; }
        public string Name { get; set; }
        public int Id { get; set; } = -1;
        public bool Persistent { get; set; }
        public int BackgroundColor { get; set; } = 0xA0A0A0;
        public int Width { get; set; } = 640;
        public int Height { get; set; } = 480;

        public GameRoom(GameContext context)
        {
            Context = context;
            RoomManagedInstances = new WindowedIndexedResourceManager<IInstance>(Context.AllInstances);
            DeactivatedInstances = new WindowedIndexedResourceManager<IInstance>(Context.AllInstances);
        }

        public virtual void Creation()
        {
        }
    }
}