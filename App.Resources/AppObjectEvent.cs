using App.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Resources
{
    public class AppObjectEvent : IAppObjectEvent
    {
        public int EventNumber { get; set; }
        public List<IAppAction> Actions { get; set; }

        public AppObjectEvent(int numb, List<IAppAction> list)
        {
            EventNumber = numb;
            Actions = list;
        }
    }
}
