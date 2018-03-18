using GameCreator.Core;

namespace GameCreator.Engine
{
    public sealed class GameInstance : IInstanceVars, IIndexedResource
    {
        public IGameContext Context { get; }
        public int Id { get; set; } = -1;
        public int InstanceId => Id;
        public int ObjectIndex => AssignedObject.Id;
        public double X { get; set; }
        public double Y { get; set; }
        public bool Persistent { get; set; }
        public double Depth { get; set; }
        public int SpriteIndex { get; set; } = -1;
        public int ImageIndex { get; set; }
        public double ImageAngle { get; set; }
        public uint ImageBlend { get; set; } = 0xFFFFFF;
        public int ImageAlpha { get; set; } = 255;
        public double ImageXScale { get; set; } = 1.0;
        public double ImageYScale { get; set; } = 1.0;
        public GameSprite Sprite => Context.Sprites[SpriteIndex];
        public GameObject AssignedObject { get; private set; }

        internal GameInstance(IGameContext context, double x, double y, GameObject assignedObject)
        {
            Context = context;
            X = x;
            Y = y;
            AssignedObject = assignedObject;
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