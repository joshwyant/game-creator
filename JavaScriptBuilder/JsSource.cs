using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JavaScriptBuilder
{
    public class JsSource
    {
        public TextWriter Writer { get; set; }
        public JsFormatter Formatter { get; set; }

        public JsSource(TextWriter writer, JsFormatter formatter = null)
        {
            Writer = writer;

        }
    }
}
