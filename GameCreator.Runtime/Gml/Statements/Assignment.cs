namespace GameCreator.Framework.Gml
{
    class Assignment : Stmt
    {
        Access a; Expr x;
        public Assignment(Access acc, Expr e, int l, int c) :base(l,c) { a = acc; x = e; }
        protected override void run()
        {
            a.Set(x.Eval());
        }
    }
}
