using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaScriptBuilder.Expressions
{
    public class JsWhile : Js
    {
        public Js Condition { get; set; }
        public Js Action { get; set; }

        public JsWhile(Js condition, Js action)
        {
            Condition = condition;
            Action = action;
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, JsFormatter formatter)
        {
            writer.Write("while");
            writer.Write(formatter.Padding + "(");
            Condition.Write(writer, formatter);
            writer.Write(")" + formatter.Padding);
            Action.Write(writer, formatter);
        }
    }
}