using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.IDE
{
    class ActionArgument
    {
        public ActionArgument()
        {
            Caption = string.Empty;
            Type = ActionArgumentType.Expression;
            DefaultValue = "0";
            Menu = "item1|item2";
        }
        public string Caption { get; set; }
        public ActionArgumentType Type { get; set; }
        public string DefaultValue { get; set; }
        public string Menu { get; set; }
    }
}
