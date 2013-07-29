using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaScriptBuilder.Expressions
{
    public class JsKeywordBinary : JsBinary
    {
        public JsKeywordBinary(Js left, Js right, string keyword)
            : base(left, right, keyword) { }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, JsFormatter formatter)
        {
            Left.Write(writer, formatter);
            writer.Write(string.Format("{1}{0}{1}", Operator, " "));
            Right.Write(writer, formatter);
        }
    }
}
