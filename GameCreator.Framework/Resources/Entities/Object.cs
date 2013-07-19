using System.Collections.Generic;
using System;

namespace GameCreator.Framework
{
    public class Object : NamedIndexedResource
    {
        public int SpriteIndex { get; set; }
        public double Depth { get; set; }
        int parent;
        public int Parent
        {
            get
            {
                return parent;
            }
            set
            {
                if (value != -1 && Context.Objects[value].DescendsFrom(Id))
                    throw new InvalidOperationException("This will create a loop in parents.");

                parent = value;
            }
        }

        public Dictionary<EventType, Dictionary<int, Event>> Events { get; set; }

        internal Object(ResourceContext context, string name = null, int index = -1, int parent = -1)
            : base(context, name)
        {
            Context.Objects.Install(this, index);
            Parent = parent;

            if (name == null)
                Name = string.Format("object{0}", Id);
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
