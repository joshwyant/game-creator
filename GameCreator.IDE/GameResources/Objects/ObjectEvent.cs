using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Runtime;

namespace GameCreator.IDE
{
    class ObjectEvent
    {
        public EventType EventType { get; set; }
        public int EventNumber { get; set; }
        public List<ActionDeclaration> Actions { get; set; }
        public ObjectEvent(EventType type, int num)
        {
            EventType = type;
            EventNumber = num;
            Actions = new List<ActionDeclaration>();
        }
        public ObjectEvent(MouseEventNumber num) : this(EventType.Mouse, (int)num) { }
        public ObjectEvent(OtherEventNumber num) : this(EventType.Other, (int)num) { }
        public ObjectEvent(StepEventNumber num) : this(EventType.Step, (int)num) { }
        public ObjectEvent(EventType type, VirtualKeyCode num) : this(type, (int)num) { }
    }
}
