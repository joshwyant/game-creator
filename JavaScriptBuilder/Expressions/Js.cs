using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.CodeDom.Compiler;

namespace JavaScriptBuilder.Expressions
{
    public partial class Js
    {
        protected Js() { }

        internal virtual void Write(IndentedTextWriter writer, JsFormatter formatter)
        {
            throw new InvalidOperationException();
        }

        public void Write(TextWriter tw, JsFormatter formatter = null)
        {
            if (formatter == null)
                formatter = JsFormatter.Default;

            using (var writer = GetIndentedTextWriter(tw, formatter))
            {
                Write(writer, formatter);
            }
        }

        internal static IndentedTextWriter GetIndentedTextWriter(TextWriter writer, JsFormatter formatter)
        {
            return new IndentedTextWriter(writer, formatter.TabString) { NewLine = formatter.Newline };
        }

        public virtual string ToString(JsFormatter formatter)
        {
            using (var sw = new StringWriter())
            {
                Write(sw, formatter);

                return sw.ToString();
            }
        }

        public override string ToString()
        {
            return ToString(null);
        }
    }
}
