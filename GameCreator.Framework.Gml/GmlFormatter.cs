using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public sealed class GmlFormatter
    {
        public string TabString { get; set; }
        internal string Newline { get; set; }
        internal string Padding { get; set; }

        public GmlFormatter() : this(2) { }

        public GmlFormatter(int spaces)
        {
            TabString = new string(' ', spaces);
            Newline = "\r\n";
            Padding = " ";
        }

        public static GmlFormatter Minifier
        {
            get
            {
                return new GmlFormatter()
                {
                    TabString = "",
                    Newline = "",
                    Padding = "",
                };
            }
        }

        public static GmlFormatter Default { get { return new GmlFormatter(); } }

        public static GmlFormatter Tabbed { get { return new GmlFormatter() { TabString = "\t" }; } }
    }
}
