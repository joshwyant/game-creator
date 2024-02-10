using System;
namespace GameCreator.Framework.Gml
{
    class AndAssignment : Assignment
    {
        public AndAssignment(Access a, Expression e, int l, int c)
            : base(a, e, l, c) { }

        public override StatementKind Kind
        {
            get { return StatementKind.AndAssignment; }
        }

        public override string Operator { get { return "&="; } }
    }
}
