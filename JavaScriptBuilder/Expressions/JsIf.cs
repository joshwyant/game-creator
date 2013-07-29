using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaScriptBuilder.Expressions
{
    public class JsIf : Js
    {
        public Js Condition { get; set; }
        public Js Action { get; set; }
        public Js Else { get; set; }

        public JsIf(Js condition, Js action, Js actionElse)
        {
            Condition = condition;
            Action = action;
            Else = actionElse;
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, JsFormatter formatter)
        {
            writer.Write("if");
            writer.Write(formatter.Padding + "(");
            Condition.Write(writer, formatter);
            writer.Write(")" + formatter.Padding);
            Action.Write(writer, formatter);
            if (Else != null)
            {
                writer.Write("else");
                writer.Write(Else is JsBlock ? formatter.Padding : " ");
                Else.Write(writer, formatter);
            }
        }
    }
}