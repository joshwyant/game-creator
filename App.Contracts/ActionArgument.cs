using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Contracts
{
    public struct ActionArgument
    {
        public ActionArgumentType Type;
        public string Value;

        public ActionArgument(ActionArgumentType type)
        {
            Type = type;
            Value = null;
        }
    }
}
