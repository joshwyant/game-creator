using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework
{
    class ErrorDefinition
    {
        public Error Type { get; set; }
        public ErrorSeverity Severity { get; set; }
        public string Message { get; set; }
    }
}
