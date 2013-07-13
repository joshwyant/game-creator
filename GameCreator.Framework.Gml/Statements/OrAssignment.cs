using System;
namespace GameCreator.Framework.Gml
{
    class OrAssignment : Assignment
    {
        public OrAssignment(Access a, Expression e, int l, int c)
            : base(a, e, l, c) { }

        public override StatementKind Kind
        {
            get { return StatementKind.OrAssignment; }
        }

        public override string Operator { get { return "|="; } }
    }
}
