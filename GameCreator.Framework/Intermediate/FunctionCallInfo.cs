using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework.Gml;

namespace GameCreator.Framework.Intermediate
{
    public class FunctionCallInfo
    {
        public BaseFunction Function { get; set; }
        public int ArgumentCount { get; set; }
    }
}
