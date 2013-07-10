namespace GameCreator.Framework.Gml
{
    class Assignment : Statement
    {
        Access a; Expression x;
        public Assignment(Access acc, Expression e, int l, int c) :base(l,c) { a = acc; x = e; }
        protected override void run()
        {
            a.Set(x.Eval());
        }
    }
}
