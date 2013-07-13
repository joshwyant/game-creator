using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Id : Expression
    {
        public string Name { get; set; }

        public Id(string n, int line, int col) : base(line, col) { this.Name = n; }
        public override string ToString() { return Name; }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Id; }
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            // Id is not a valid as an expression, as it is only used during parsing.
            throw new InvalidOperationException();
        }

        public override string ToString(GmlFormatter formatter)
        {
            return Name;
        }
    }
}
