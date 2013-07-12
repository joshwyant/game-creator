namespace GameCreator.Framework.Gml
{
    class SubtractionAssignment : Assignment
    {
        public SubtractionAssignment(Access a, Expression e, int l, int c)
            : base(a, e, l, c) { }

        public override StatementKind Kind
        {
            get { return StatementKind.SubtractionAssignment; }
        }
    }
}
