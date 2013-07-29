using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaScriptBuilder
{
    public sealed class JsFormatter
    {
        public string TabString { get; set; }
        internal string Newline { get; set; }
        internal string Padding { get; set; }

        public JsFormatter() : this(4) { }

        public JsFormatter(int spaces)
        {
            TabString = new string(' ', spaces);
            Newline = "\r\n";
            Padding = " ";
        }

        public static JsFormatter Minifier
        {
            get
            {
                return new JsFormatter()
                {
                    TabString = "",
                    Newline = "",
                    Padding = "",
                };
            }
        }

        public static JsFormatter Default { get { return new JsFormatter(); } }

        public static JsFormatter Tabbed { get { return new JsFormatter() { TabString = "\t" }; } }
    }
}
