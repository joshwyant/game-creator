namespace GameCreator.Framework.Gml
{
    class DivideAssignment : Assignment
    {
        public DivideAssignment(Access a, Expression e, int l, int c)
            : base(a, e, l, c) { }

        public override StatementKind Kind
        {
            get { return StatementKind.DivideAssignment; }
        }
    }
}
