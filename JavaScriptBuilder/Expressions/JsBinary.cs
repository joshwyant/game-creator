using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaScriptBuilder.Expressions
{
    public class JsBinary : Js
    {
        public string Operator { get; set; }
        public Js Left { get; set; }
        public Js Right { get; set; }

        public JsBinary(Js left, Js right, string op)
        {
            Left = left;
            Right = right;
            Operator = op;
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, JsFormatter formatter)
        {
            Left.Write(writer, formatter);
            writer.Write(string.Format("{1}{0}{1}", Operator, formatter.Padding));
            Right.Write(writer, formatter);
        }
    }
}
