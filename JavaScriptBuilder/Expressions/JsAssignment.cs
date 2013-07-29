using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaScriptBuilder.Expressions
{
    public class JsAssignment : JsBinary
    {
        public JsAssignment(Js left, Js right, string op)
            : base(left, right, op) { }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, JsFormatter formatter)
        {
            base.Write(writer, formatter);
            writer.WriteLine(";");
        }
    }
}
