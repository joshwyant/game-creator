using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaScriptBuilder.Expressions
{
    public class JsVariable : Js
    {
        public string Name { get; set; }

        public JsVariable(string name)
        {
            Name = name;
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, JsFormatter formatter)
        {
            writer.Write(Name);
        }
    }
}
