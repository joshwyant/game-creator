using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework
{
    public enum EventType : int
    {
        Create = 0,
        Destroy = 1,
        Step = 3,
        Alarm = 2,
        Keyboard = 5,
        Mouse = 6,
        Collision = 4,
        Other = 7,
        Draw = 8,
        KeyPress = 9,
        KeyRelease = 10,
        Trigger = 11,
    }
}
