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
    }
}
