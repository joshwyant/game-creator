using System.Collections.Generic;

namespace GameCreator.Framework
{
    public class Object : NamedIndexedResource
    {
        public int SpriteIndex { get; set; }
        public double Depth { get; set; }
        public int Parent { get; set; }

        public Dictionary<EventType, Dictionary<int, Event>> Events { get; set; }

        internal Object(ResourceContext context)
            : base(context, null)
        {
            Context.Objects.Install(this);
            Parent = -1;
            Name = string.Format("object{0}", Id);
        }

        internal Object(ResourceContext context, string name)
            : base(context, name)
        {
            Context.Objects.Install(this);
            Parent = -1;
        }

        internal Object(ResourceContext context, string name, int index)
            : base(context, name)
        {
            Context.Objects.Install(this, index);
            Parent = -1;
        }

        void Initialize()
        {
            Events = new Dictionary<EventType, Dictionary<int, Event>>();
        }

        internal bool EventDefined(EventType etype, int num)
        {
            return Events.ContainsKey(etype) && Events[etype].ContainsKey(num);
        }

        public Event DefineEvent(int e, int num)
        {
            Dictionary<int, Event> evholder = null;
            if (!Events.TryGetValue((EventType)e, out evholder))
            {
                evholder = new Dictionary<int, Event>();
                Events.Add((EventType)e, evholder);
            }
            Event ev = null;
            if (!evholder.TryGetValue(num, out ev))
            {
                ev = new Event(this, (EventType)e, num);
                evholder.Add(num, ev);
            }
            return ev;
        }

        public bool DescendsFrom(int index)
        {
            return (index == Parent || (Parent != -1 && Context.Objects[Parent].DescendsFrom(index)));
        }
    }
}
