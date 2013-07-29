using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaScriptBuilder.Expressions
{
    public class JsBlock : Js
    {
        public IEnumerable<Js> Body { get; set; }

        public JsBlock(params Js[] body)
        {
            Body = body;
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, JsFormatter formatter)
        {
            writer.WriteLine("{");
            writer.Indent++;
            foreach (var js in Body)
                js.Write(writer, formatter);
            writer.Indent--;
            writer.Write("}");
        }
    }
}
