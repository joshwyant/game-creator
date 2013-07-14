using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework
{
    public class StepEvents
    {
        public static string[] Names { get { return names; } }
        static string[] names = new string[] {
            "Step",
            "Begin Step",
            "End Step",
        };
    }
}
