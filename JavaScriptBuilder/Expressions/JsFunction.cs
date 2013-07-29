using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaScriptBuilder.Expressions
{
    public class JsFunction : Js
    {
        public string Name { get; set; }
        public IEnumerable<Js> Body { get; set; }
        public IEnumerable<string> Parameters { get; set; }

        public JsFunction(string name, IEnumerable<Js> body, params string[] parameters)
        {
            Name = name;
            Body = body;
            Parameters = parameters;
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, JsFormatter formatter)
        {
            writer.Write("function");
            if (!string.IsNullOrEmpty(Name))
                writer.Write(string.Concat(" ", Name));
            writer.Write(formatter.Padding + "(");
            writer.Write(string.Join("," + formatter.Padding, Parameters));
            writer.Write(")" + formatter.Padding);
            writer.WriteLine("{");
            writer.Indent++;
            foreach (var js in Body)
                js.Write(writer, formatter);
            writer.Indent--;
            writer.Write("}");
        }
    }
}
