using GameCreator.Core;

namespace GameCreator.Engine
{
    public sealed class GameInstance : IInstanceVars, IIndexedResource
    {
        public IGameContext Context { get; }
        public int Id { get; set; }
        public int InstanceId => Id;
        public int ObjectIndex => AssignedObject.Id;
        public double X { get; set; }
        public double Y { get; set; }
        public bool Persistent { get; set; }
        public double Depth { get; set; }
        public GameObject AssignedObject { get; private set; }

        internal GameInstance(IGameContext context, double x, double y, GameObject assignedObject)
        {
            Context = context;
            X = x;
            Y = y;
            AssignedObject = assignedObject;
            context.Instances.Add(this);
        }

        public void Change(GameObject assignedObject, bool performEvents)
        {
            if (performEvents)
            {
                PerformEvent(EventType.Destroy);
            }
            AssignedObject = assignedObject;
            if (performEvents)
            {
                PerformEvent(EventType.Create);
            }
        }

        public void PerformEvent(EventType eventType, int eventNumber = 0)
        {
            AssignedObject.PerformEvent(this, eventType, eventNumber);
        }
    }
}