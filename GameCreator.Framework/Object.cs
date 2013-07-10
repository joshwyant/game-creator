using System.Collections.Generic;

namespace GameCreator.Framework
{
    public class Object : IndexedResource
    {
        public static IndexedResourceManager Manager = new IndexedResourceManager();
        public int SpriteIndex { get; set; }
        public double Depth { get; set; }
        Dictionary<EventType, Dictionary<int, Event>> Events = new Dictionary<EventType, Dictionary<int, Event>>();
        Object(string name) : base(name) { Manager.Install(this); }
        Object(string name, int index) : base(name) { Manager.Install(this, index); }
        internal void PerformEvent(Instance e, EventType ev, int num)
        {
            if (e.Destroyed) return;
            if (EventDefined(ev, num))
            {
                Instance current = Gml.ExecutionContext.Current;
                Gml.ExecutionContext.Current = e;
                Events[ev][num].Execute();
                Gml.ExecutionContext.Current = current;
            }
        }
        internal bool EventDefined(EventType ev, int num)
        {
            return Events.ContainsKey(ev) && Events[ev].ContainsKey(num);
        }
        public Event DefineEvent(int e, int num)
        {
            Dictionary<int, Event> ev = null;
            if (!Events.TryGetValue((EventType)e, out ev))
            {
                ev = new Dictionary<int, Event>();
                Events.Add((EventType)e, ev);
            }
            Event @event = null;
            if (!ev.TryGetValue(num, out @event))
            {
                @event = new Event((EventType)e, num);
                ev.Add(num, @event);
            }
            return @event;
        }
        public static Object Define(string name)
        {
            return new Object(name);
        }
        public static Object Define(string name, int index)
        {
            return new Object(name, index);
        }
    }
}
