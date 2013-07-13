using System;
namespace GameCreator.Framework.Gml
{
    class AdditionAssignment : Assignment
    {
        public AdditionAssignment(Access a, Expression e, int l, int c)
            : base(a, e, l, c) { }

        public override StatementKind Kind
        {
            get { return StatementKind.AdditionAssignment; }
        }

        public override string Operator { get { return "+="; } }
    }
}
