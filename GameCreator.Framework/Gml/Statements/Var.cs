using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Var : Statement
    {
        public string[] Variables { get; set; }

        public Var(string[] v, int l, int c) : base(l, c) { Variables = v; }

        public override string ToString()
        {
            return "var "+string.Join(", ", Variables);
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Var; }
        }
    }
}
