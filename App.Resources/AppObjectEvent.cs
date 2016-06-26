using App.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Resources
{
    public class AppObjectEvent : IAppObjectEvent
    {
        public EventType EventType { get; set; }
        public int EventNumber { get; set; }
        public List<IAppAction> Actions { get; set; }

        public AppObjectEvent(EventType type, int numb, List<IAppAction> list)
        {
            EventType = type;
            EventNumber = numb;
            Actions = list;
        }
    }
}
