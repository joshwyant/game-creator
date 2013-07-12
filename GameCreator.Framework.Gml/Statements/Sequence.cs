using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Sequence : Statement
    {
        public Statement First { get; set; }
        public Statement Second { get; set; }

        public Sequence(Statement s1, Statement s2, int line, int col)
            : base(line, col)
        {
            First = s1;
            Second = s2;
        }

        public override string ToString()
        {
            return First.ToString() + "; " + Second.ToString();
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Sequence; }
        }

        public override void Optimize()
        {
            First.Optimize();
            Second.Optimize();
        }
    }
}
