using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Constant : Expression
    {
        public Value Value { get; set; }
        public Constant(string s, int line, int col) : base(line, col) { Value = new Value(s); }
        public Constant(double d, int line, int col) : base(line, col) { Value = new Value(d); }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Constant; }
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            if (Value.IsString)
                writer.Write(Value.String.Contains("\"") ? string.Format("'{0}'", Value.String) : string.Format("\"{0}\"", Value.String));
            else
            {
                writer.Write((long)Math.Floor(Value.Real));
                if (Value.Real - Math.Floor(Value.Real) != 0)
                {
                    writer.Write(".");
                    // TODO: Do this correctly.
                    var frac = (long)(Math.Floor(Value.Real) * 1000000000000000.0);
                    while (frac % 10 == 0)
                        frac /= 10;
                    writer.Write(frac);
                }
            }
        }
    }
}
