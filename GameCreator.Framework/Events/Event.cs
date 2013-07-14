using System;
using System.Collections.Generic;

namespace GameCreator.Framework
{
    // Holds a list of actions in either an event or a timeline moment
    public class Event
    {
        public Object Object { get; set; }
        public EventType EventType { get; set; }
        public int EventNumber { get; set; }
        public List<Action> Actions { get; set; }
        internal Event(Object obj, EventType type, int num)
        {
            Object = obj;
            EventType = type;
            EventNumber = num;
            Actions = new List<Action>();
        }
        public void DefineAction(int libid, int actionid, string[] args, int appliesto, bool relative, bool not)
        {
            Actions.Add(new Action(Object.Context, libid, actionid, args, appliesto, relative, not));
        }
    }
}