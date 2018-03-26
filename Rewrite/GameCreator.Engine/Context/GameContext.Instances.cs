using GameCreator.Resources.Api;
using GameCreator.Runtime.Api;

namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        public IIndexedResourceManager<IInstance> Instances { get; }

        public GameInstance CreateInstance(double x, double y, GameObject assignedObject)
        {
            // TODO: Unit tests
            var inst = new GameInstance(this, x, y, assignedObject);
            assignedObject.InitializeInstance(inst);
            Instances.Add(inst);
            CurrentRoom?.CreatedInstances?.Add(inst.Id);
            PresortedInstances.Add(inst);
            return inst;
        }
    }
}