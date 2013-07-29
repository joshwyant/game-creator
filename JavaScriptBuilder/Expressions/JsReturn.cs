using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaScriptBuilder.Expressions
{
    public class JsReturn : Js
    {
        public Js Expression { get; set; }

        public JsReturn(Js js)
        {
            Expression = js;
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, JsFormatter formatter)
        {
            writer.Write("return ");
            Expression.Write(writer, formatter);
            writer.WriteLine(";");
        }
    }
}
