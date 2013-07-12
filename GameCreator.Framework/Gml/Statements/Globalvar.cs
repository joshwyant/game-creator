using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class Globalvar : Statement
    {
        public string[] Variables { get; set; }

        public Globalvar(string[] v, int line, int col)
            : base(line, col)
        {
            Variables = v;
        }

        public override string ToString()
        {
            return "globalvar " + string.Join(", ", Variables);
        }
        public override StatementKind Kind
        {
            get { return StatementKind.Globalvar; }
        }
    }
}
