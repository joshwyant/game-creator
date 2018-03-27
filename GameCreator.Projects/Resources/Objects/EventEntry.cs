using System.Collections.Generic;
using GameCreator.Resources.Api;

namespace GameCreator.Projects
{
    public class EventEntry
    {
        public EventType EventType { get; }
        public int EventNumber { get; }
        public List<ActionEntry> Actions { get; }

        public EventEntry(EventType type, int numb, List<ActionEntry> list)
        {
            EventType = type;
            EventNumber = numb;
            Actions = list;
        }
    }
}