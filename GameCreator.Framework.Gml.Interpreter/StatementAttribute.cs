using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml.Interpreter
{
    class StatementAttribute : Attribute
    {
        public StatementKind Kind { get; set; }
    }
}
