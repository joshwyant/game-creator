using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom.Compiler;
using System.IO;


namespace GameCreator.Framework.Gml
{
    public abstract class AstNode
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public AstNode(int line, int col) { Line = line; Column = col; }
        abstract internal void Write(IndentedTextWriter writer, GmlFormatter formatter);

        public void Write(TextWriter tw, GmlFormatter formatter = null)
        {
            if (formatter == null)
                formatter = GmlFormatter.Default;

            using (var writer = GetIndentedTextWriter(tw, formatter))
            {
                Write(writer, formatter);
            }
        }

        public virtual string ToString(GmlFormatter formatter)
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
        internal static IndentedTextWriter GetIndentedTextWriter(TextWriter writer, GmlFormatter formatter)
        {
            return new IndentedTextWriter(writer, formatter.TabString) { NewLine = formatter.Newline };
        }
    }
}
