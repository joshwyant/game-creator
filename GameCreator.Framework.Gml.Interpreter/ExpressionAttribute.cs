using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    class ExpressionAttribute : Attribute
    {
        public ExpressionKind Kind { get; set; }
    }
}
