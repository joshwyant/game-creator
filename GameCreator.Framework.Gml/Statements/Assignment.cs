namespace GameCreator.Framework.Gml
{
    public class Assignment : Statement
    {
        public Access Lefthand { get; set; }
        public Expression Expression { get; set; }

        public Assignment(Access acc, Expression e, int l, int c)
            : base(l, c)
        {
            Lefthand = acc;
            Expression = e;
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Assignment; }
        }

        public override void Optimize()
        {
            Expression = Expression.Reduce();
        }
    }
}
