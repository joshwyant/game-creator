using GameCreator.Resources.Api;
using GameCreator.Runtime.Api;

namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        public IIndexedResourceManager<IInstance> Instances => CurrentRoom.RoomManagedInstances;
        public IIndexedResourceManager<IInstance> AllInstances;

        public GameInstance CreateInstance(double x, double y, GameObject assignedObject)
        {
            // TODO: Unit tests
            var inst = new GameInstance(this, x, y, assignedObject);
            assignedObject.InitializeInstance(inst);
            Instances.Add(inst);
            PresortedInstances.Add(inst);
            return inst;
        }
    }
}