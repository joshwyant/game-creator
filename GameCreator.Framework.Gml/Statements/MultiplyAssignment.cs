namespace GameCreator.Framework.Gml
{
    class MultiplyAssignment : Assignment
    {
        public MultiplyAssignment(Access a, Expression e, int l, int c)
            : base(a, e, l, c) { }

        public override StatementKind Kind
        {
            get { return StatementKind.MultiplyAssignment; }
        }
    }
}
